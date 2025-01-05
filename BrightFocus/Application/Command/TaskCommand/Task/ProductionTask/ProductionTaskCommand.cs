

namespace BrightFocus.Application.Command.TaskCommand.Task.ProductionTask
{
    public class ProductionTaskCommand : CreateOrUpdateTaskRequest, IMapFrom<TaskProductionEntity>, IRequest<MResponse<bool>>
    {
    }
}
