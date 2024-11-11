namespace BrightFocus.Data.Query
{
    public class TaskDetailQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext,
        IMapper mapper) : MQuery<TaskDetail>(dbContext, authContext), ITaskDetailQuery
    {
        public async Task<List<TaskDetail>?> GetTaskDetailByTaskNoAsync(Guid taskId)
        {
            List<TaskDetail>? query = await Queryable.Where(x => x.TaskId == taskId).ToListAsync();
            return query is null ? null : query;
        }

        public async Task<MPagedResult<TaskDetailDto>> GetTaskDetailPagingAsync
            (Guid taskId, int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
        {
            IQueryable<TaskDetail> query = Queryable.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.ProductName.Contains(keyword));
            }

            int rowCount = await query.CountAsync();

            IQueryable<TaskDetail> items = query
                .Where(x => x.TaskId == taskId)
                .OrderBy(x => x.ProductName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            MPagedResult<TaskDetailDto> result = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<TaskDetailDto>(items)]
            };
            return result;
        }
    }
}
