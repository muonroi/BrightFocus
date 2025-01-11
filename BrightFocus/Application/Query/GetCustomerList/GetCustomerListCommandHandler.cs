

namespace BrightFocus.Application.Query.GetCustomerList
{
    public class GetCustomerListCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ICustomerQuery customerQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetCustomerListCommand, MResponse<IEnumerable<CustomerModel>>>
    {
        public async Task<MResponse<IEnumerable<CustomerModel>>> Handle(GetCustomerListCommand request, CancellationToken cancellationToken)
        {
            MResponse<IEnumerable<CustomerModel>> result = new();
            IEnumerable<CustomerModel> customers = await customerQuery.GetCustomersAsync();
            result.Result = customers;
            return result;
        }
    }
}
