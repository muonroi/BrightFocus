namespace BrightFocus.Data.Query;

public class TaskListQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<TaskList>(dbContext, authContext), ITaskListQuery
{
    public async Task<MResponse<MPagedResult<TaskListDto>>> GetTaskListPagingAsync(int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
    {
        MResponse<MPagedResult<TaskListDto>> result = new();

        IQueryable<TaskList> query = dbContext.TaskLists.AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.ProductName.Contains(keyword));
        }

        int rowCount = await query.CountAsync();

        IQueryable<TaskList> items = query
            .OrderBy(x => x.ProductName)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        List<TaskListDto> taskListDtos = await items
       .Select(taskList => new TaskListDto
       {
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
                   ProductName = td.ProductName,
                   Material = td.Material,
                   Size = td.Size,
                   Weight = td.Weight,
                   Color = td.Color,
                   Employee = td.Employee,
                   Warehouse = td.Warehouse,
                   DeadlineDate = td.DeadlineDate,
                   Note = td.Note,
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
