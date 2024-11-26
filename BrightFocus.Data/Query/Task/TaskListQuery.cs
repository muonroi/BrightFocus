







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

    public async Task<MResponse<MPagedResult<TaskListDto>>> GetTaskListPagingAsync(
    int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
    {
        MResponse<MPagedResult<TaskListDto>> result = new();

        MPagedResult<TaskListDto> pagedResult = await GetPagedAsync(
            Queryable,
            pageIndex,
            pageSize,
            taskList => new TaskListDto
            {
                EntityId = taskList.EntityId,
                TaskName = taskList.TaskName,
                ProductName = taskList.ProductName,
                Material = taskList.Material,
                Size = taskList.Size,
                Weight = taskList.Weight,
                Quantification = taskList.Quantification,
                Color = taskList.Color,
                Characteristic = taskList.Characteristic ?? string.Empty,
                Quantity = taskList.Quantity,
                Employee = taskList.Employee,
                FactoryName = taskList.FactoryName ?? string.Empty,
                Warehouse = taskList.Warehouse ?? string.Empty,
                DeadlineDate = taskList.DeadlineDate,
                Note = taskList.Note ?? string.Empty,
                FileUrl = taskList.FileUrl,
                CreationTime = taskList.CreationTime,
                TaskDetails = dbContext.TaskDetails
                    .Where(td => td.TaskId == taskList.EntityId)
                    .Select(td => new TaskDetailDto
                    {
                        EntityId = td.EntityId,
                        ProductName = td.ProductName ?? string.Empty,
                        Material = td.Material ?? string.Empty,
                        Quantification = td.Quantification ?? 0.0,
                        Width = td.Width ?? 0.0,
                        Color = td.Color,
                        Characteristic = td.Characteristic,
                        Quantity = td.Quantity,
                        Warehouse = td.Warehouse,
                        FileNumber = td.FileNumber,
                        Employee = td.Employee,
                        DeadlineDate = td.DeadlineDate,
                        Note = td.Note,
                        TaskId = td.TaskId
                    }).ToList()
            },
            keyword,
            x => string.IsNullOrEmpty(keyword) || x.ProductName.Contains(keyword),
            queryable =>
            {
                string validSortBy = string.IsNullOrWhiteSpace(sortBy) ? "CreationTime" : sortBy;
                return sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase)
                    ? queryable.OrderByDescending(x => EF.Property<object>(x, validSortBy))
                    : queryable.OrderBy(x => EF.Property<object>(x, validSortBy));
            });

        result.Result = pagedResult;
        return result;
    }

}
