



namespace BrightFocus.Data.Query.TaskDetail;

public class TaskDetailQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<TaskDetailEntity>(dbContext, authContext), ITaskDetailQuery
{
    public async Task<List<TaskDetailEntity>> GetTaskDetailByTaskNoAsync(Guid taskId)
    {
        return await Queryable.Where(x => x.TaskId == taskId).ToListAsync();
    }


    public async Task<MResponse<MPagedResult<TaskDetailDto>>> GetTaskDetailPagingAsync
    (Guid taskId, int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
    {
        MResponse<MPagedResult<TaskDetailDto>> result = new();

        MPagedResult<TaskDetailDto> pagedResult = await GetPagedAsync(
            Queryable,
            pageIndex,
            pageSize,
            td => new TaskDetailDto
            {
                EntityId = td.EntityId,
                ProductName = td.ProductName ?? string.Empty,
                Material = td.Material ?? string.Empty,
                Quantification = td.Quantification ?? 0,
                Width = td.Width ?? 0,
                Color = td.Color,
                Characteristic = td.Characteristic,
                Quantity = td.Quantity,
                Employee = td.Employee,
                Warehouse = td.Warehouse,
                DeadlineDate = td.DeadlineDate,
                Note = td.Note ?? string.Empty,
                TaskId = td.TaskId
            },
            keyword,
        x => string.IsNullOrEmpty(keyword) || (x.ProductName ?? string.Empty).Contains(keyword),
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


    public async Task<List<TaskDetailEntity>> GetTaskDetailsByTaskIdsAsync(List<Guid> foundTaskIds)
    {
        return foundTaskIds == null || foundTaskIds.Count == 0
            ? ([])
            : await Queryable
            .Where(x => foundTaskIds.Contains(x.TaskId))
            .ToListAsync();
    }

}
