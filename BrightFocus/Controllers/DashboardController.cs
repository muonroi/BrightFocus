

namespace BrightFocus.Controllers;

[Route("dashboard")]
[ApiVersion("1")]
public class DashboardController(IMediator mediator, Serilog.ILogger logger
, IMapper mapper
, IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
{
    [HttpGet]
    public async Task<IActionResult> GetTaskById([FromQuery] Guid id)
    {
        MResponse<TaskInListDto> response = new();
        TaskList? task = await unitOfWork.TaskListRepository.GetByGuidAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        TaskInListDto result = mapper.Map<TaskList, TaskInListDto>(task);
        response.Result = result;
        return Ok(response);
    }

    [HttpGet("paging")]
    public async Task<IActionResult> GetTaskListPaging([FromQuery] string keyword, int pageIndex, int pageSize)
    {
        MResponse<MPagedResult<TaskInListDto>> result = await unitOfWork.TaskListRepository.GetTaskListPagingAsync(pageIndex, pageSize, keyword);
        return Ok(result);
    }

    [HttpPost]
    [Permission<Permission>(Permission.Task_Create)]
    public async Task<IActionResult> CreateTask([FromBody] CreateOrUpdateTaskRequest request)
    {
        TaskList task = mapper.Map<CreateOrUpdateTaskRequest, TaskList>(request);

        _ = unitOfWork.TaskListRepository.Add(task);

        int result = await unitOfWork.CompleteAsync();
        return result > 0 ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] CreateOrUpdateTaskRequest request)
    {
        TaskList? task = await unitOfWork.TaskListRepository.GetByGuidAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        _ = mapper.Map(request, task);

        int result = await unitOfWork.CompleteAsync();
        return result > 0 ? Ok() : BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTask([FromQuery] Guid[] ids)
    {
        foreach (Guid id in ids)
        {
            TaskList? task = await unitOfWork.TaskListRepository.GetByGuidAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            _ = await unitOfWork.TaskListRepository.DeleteAsync(task);
        }
        int result = await unitOfWork.CompleteAsync();
        return result > 0 ? Ok() : BadRequest();
    }
}
