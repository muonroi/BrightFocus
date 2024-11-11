namespace BrightFocus.Data.Query
{
    public class TaskListQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext,
        IMapper mapper) : MQuery<TaskList>(dbContext, authContext), ITaskListQuery
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

            MPagedResult<TaskListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<TaskListDto>(items)]
            };
            result.Result = data;
            return result;
        }
    }
}
