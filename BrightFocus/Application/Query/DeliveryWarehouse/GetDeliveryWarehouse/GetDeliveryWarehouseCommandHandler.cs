

namespace BrightFocus.Application.Query.DeliveryWarehouse.GetDeliveryWarehouse
{
    public class GetDeliveryWarehouseCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
        IDeliveryWarehouseQuery deliveryWarehouseQuery) :
        BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetDeliveryWarehouseCommand, MResponse<IEnumerable<DeliveryWarehouseDto>>>
    {
        public async Task<MResponse<IEnumerable<DeliveryWarehouseDto>>> Handle(GetDeliveryWarehouseCommand request, CancellationToken cancellationToken)
        {
            MResponse<IEnumerable<DeliveryWarehouseDto>> result = new();
            List<DeliveryWarehouseEntity> deliveryWarehouse = await deliveryWarehouseQuery.GetByConditionAsync(x => x.TaskId == request.TaskId);
            result.Result = Mapper.Map<IEnumerable<DeliveryWarehouseDto>>(deliveryWarehouse);
            return result;
        }
    }
}
