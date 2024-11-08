

namespace BrightFocus.Data.Repository
{
    public class TaskDetailRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<TaskDetail>(dbContext, authContext), ITaskDetailRepository
    {
        public async Task<MResponse<MPagedResult<TaskDetailInListDto>>> GetTaskListPagingAsync(Guid taskId, int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<TaskDetailInListDto>> result = new();
            IQueryable<TaskDetail> query = dbContext.TaskDetails.AsQueryable();

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

            MPagedResult<TaskDetailInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<TaskDetailInListDto>(items)]
            };
            result.Result = data;
            return result;
        }
    }
}
