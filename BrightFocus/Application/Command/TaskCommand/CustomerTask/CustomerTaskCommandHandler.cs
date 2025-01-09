


namespace BrightFocus.Application.Command.TaskCommand.CustomerTask
{
    public class CustomerTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ICustomerTaskRepository customerTaskRepository
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<CustomerTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(CustomerTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();
            CustomerEntity customerTaskEntity = new()
            {
                TaskName = request.TaskName,
                CustomerName = request.CustomerName,
                CustomerCode = request.CustomerCode,
                Address = request.Address,
                Phone = request.Phone,
                Note = request.Note
            };
            _ = customerTaskRepository.Add(customerTaskEntity);
            _ = await customerTaskRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
