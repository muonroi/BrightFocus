




namespace BrightFocus.Data.Repository
{
    public class TaskListRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<TaskList>(dbContext, authContext), ITaskListRepository
    {
        public async Task<MResponse<MPagedResult<TaskInListDto>>> GetTaskListPagingAsync(int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<TaskInListDto>> result = new();
            IQueryable<TaskList> query = dbContext.TaskLists.AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.Name.Contains(keyword));
        }

        int rowCount = await query.CountAsync();

        IQueryable<TaskList> items = query
            .OrderBy(x => x.Name)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

            MPagedResult<TaskInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<TaskInListDto>(items)]
            };
            result.Result = data;
            return result;
        }


}
