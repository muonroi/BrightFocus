

namespace BrightFocus.Data.Query.TaskDetail;

public class TaskDetailQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext,
    IMapper mapper) : MQuery<TaskDetailEntity>(dbContext, authContext), ITaskDetailQuery
{
    public async Task<List<TaskDetailEntity>> GetTaskDetailByTaskNoAsync(Guid taskId)
    {
        return await Queryable.Where(x => x.TaskId == taskId).ToListAsync();
    }


    public async Task<MPagedResult<TaskDetailDto>> GetTaskDetailPagingAsync
    (Guid taskId, int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
    {
        IQueryable<TaskDetailEntity> query = Queryable.Where(x => x.TaskId == taskId);

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.ProductName.Contains(keyword));
        }

        int rowCount = await query.CountAsync();

        query = sortOrder.ToLower() switch
        {
            "desc" => query.OrderByDescending(x => EF.Property<object>(x, sortBy)),
            _ => query.OrderBy(x => EF.Property<object>(x, sortBy)),
        };

        IQueryable<TaskDetailEntity> items = query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        MPagedResult<TaskDetailDto> result = new()
        {
            CurrentPage = pageIndex,
            PageSize = pageSize,
            RowCount = rowCount,
            Items = await mapper.ProjectTo<TaskDetailDto>(items).ToListAsync()
        };

        return result;
    }


    public async Task<List<TaskDetailEntity>> GetTaskDetailsByTaskIdsAsync(List<Guid> foundTaskIds)
    {
        if (foundTaskIds == null || foundTaskIds.Count == 0)
        {
            return [];
        }

        return await Queryable
            .Where(x => foundTaskIds.Contains(x.TaskId))
            .ToListAsync();
    }

}
