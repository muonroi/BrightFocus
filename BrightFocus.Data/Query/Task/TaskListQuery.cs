

namespace BrightFocus.Data.Query.Task;

public class TaskListQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<TaskListEntity>(dbContext, authContext), ITaskListQuery
{
    public async Task<IEnumerable<TaskListEntity>> GetTaskByGuidsAsync(List<Guid> guids)
    {
        if (guids == null || guids.Count == 0)
        {
            return [];
        }

        List<Guid> guidsList = [.. guids];

        List<TaskListEntity> result = await Queryable
                                     .Where(task => guidsList.Contains(task.EntityId))
                                     .ToListAsync();

        return result;
    }

    public async Task<MResponse<MPagedResult<TaskListDto>>> GetTaskListPagingAsync(int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
    {
        MResponse<MPagedResult<TaskListDto>> result = new();

        IQueryable<TaskListEntity> query = dbContext.TaskLists.AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.ProductName.Contains(keyword));
        }

        int rowCount = await query.CountAsync();

        IQueryable<TaskListEntity> items = query
            .OrderBy(x => x.ProductName)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        List<TaskListDto> taskListDtos = await items
       .Select(taskList => new TaskListDto
       {
           EntityId = taskList.EntityId,
           TaskName = taskList.TaskName,
           ProductName = taskList.ProductName,
           Material = taskList.Material,
           Size = taskList.Size,
           Weight = taskList.Weight,
           Color = taskList.Color,
           Employee = taskList.Employee,
           FactoryName = taskList.FactoryName,
           Warehouse = taskList.Warehouse,
           DeadlineDate = taskList.DeadlineDate,
           Note = taskList.Note,
           FileUrl = taskList.FileUrl,

           TaskDetails = dbContext.TaskDetails

               .Where(td => td.TaskId == taskList.EntityId)
               .Select(td => new TaskDetailDto
               {
                   EntityId = td.EntityId,
                   ProductName = td.ProductName,
                   Material = td.Material,
                   Quantification = td.Quantification,
                   UnitQuantification = td.UnitQuantification,
                   Width = td.Width,
                   UnitWidth = td.UnitWidth,
                   Color = td.Color,
                   Characteristic = td.Characteristic,
                   Quantity = td.Quantity,
                   UnitQuantity = td.UnitQuantity,
                   Employee = td.Employee,
                   Warehouse = td.Warehouse,
                   DeadlineDate = td.DeadlineDate,
                   TaskId = td.TaskId
               }).ToList()
       }).ToListAsync();

        MPagedResult<TaskListDto> data = new()
        {
            CurrentPage = pageIndex,
            PageSize = pageSize,
            RowCount = rowCount,
            Items = taskListDtos
        };
        result.Result = data;
        return result;
    }
}
