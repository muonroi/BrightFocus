

namespace BrightFocus.Application.Command.UpdateWarehouse
{
    public class UpdateWarehouseCommand : IRequest<MResponse<bool>>
    {
        public IEnumerable<UpdateWarehouseRequest> Data { get; set; } = [];
    }
}
