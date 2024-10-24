

namespace BrightFocus.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        ITaskListRepository TaskListRepository { get; }
        IChemicalsRepository ChemicalsRepository { get; }
        IFibersRepository FibersRepository { get; }
        IFinishedProductRepository FinishedRepository { get; }
        IPaperTubeRepository PaperTubeRepository { get; }
        IWastesRepository WastesRepository { get; }
        IWoodsRepository WoodsRepository { get; }
        Task<int> CompleteAsync();
    }
}
