



namespace BrightFocus.Core.Interfaces.Query.CustomerTask
{
    public interface ICustomerQuery : IMQueries<CustomerEntity>
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync();
        Task<MPagedResult<CustomerModel>> GetCustomerPagingAsync(int pageIndex, int pageSize);
        Task<CustomerModel?> GetCustomerByGuidAsync(Guid entityId);
    }
}
