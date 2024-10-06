

namespace BrightFocus.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        ITaskListRepository TaskListRepository { get; }
        Task<int> CompleteAsync();
    }
}
