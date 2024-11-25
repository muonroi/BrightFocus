namespace BrightFocus.Application.Query.DeliveryWarehouse.GetDeliveryWarehouse
{
    public class GetDeliveryWarehouseCommand
        : IRequest<MResponse<IEnumerable<DeliveryWarehouseDto>>>
    {
        public Guid TaskId { get; set; }
    }
}
