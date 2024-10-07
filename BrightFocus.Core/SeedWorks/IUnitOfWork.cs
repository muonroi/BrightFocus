

namespace BrightFocus.Core.SeedWorks;

public interface IUnitOfWork
{
    ITaskListRepository TaskListRepository { get; }
    IChemicalsRepository ChemicalsRepositorys { get; }
    IFiberRepository FiberRepositorys { get; }
    IFinishProductRepository FinishProductRepositorys { get; }
    IPaperTubeRepository PaperTubeRepositorys { get; }
    IWasteProductRepository WasteProductRepositorys { get; }
    IWoodRepository WoodRepositorys { get; }
    Task<int> CompleteAsync();
}
