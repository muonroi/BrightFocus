



namespace BrightFocus.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        ITaskListRepository TaskListRepository { get; }
        IAuthenticateRepository AuthenticateRepository { get; }
        Task<int> CompleteAsync();
    }
}
