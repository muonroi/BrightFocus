



namespace BrightFocus.Core.Interfaces.Query.CustomerTask
{
    public interface ITaskCustomerQuery
        : IMQueries<CustomerEntity>
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync();
        Task<MPagedResult<CustomerModel>> GetCustomerPagingAsync(int pageIndex, int pageSize);
        Task<CustomerModel?> GetCustomerByGuidAsync(Guid entityId);
        Task<TaskResponse?> GetTaskCustomerByGuidAsync(Guid entityId);

    }
}
