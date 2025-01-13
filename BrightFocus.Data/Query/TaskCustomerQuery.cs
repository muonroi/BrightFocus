
namespace BrightFocus.Data.Query
{
    public class TaskCustomerQuery(BrightFocusDbContext dbContext,
        MAuthenticateInfoContext authContext) : MQuery<CustomerEntity>(dbContext, authContext), ITaskCustomerQuery
    {
        public async Task<TaskResponse?> GetTaskCustomerByGuidAsync(Guid entityId)
        {
            CustomerEntity? customer = await Queryable.FirstOrDefaultAsync(x => x.EntityId == entityId);
            if (customer is null)
            {
                return null;
            }
            TaskResponse result = new()
            {
                CustomerTask = new CustomerTaskResponse()
                {
                    EntityId = entityId,
                    TaskName = customer.TaskName,
                    CustomerCode = customer.CustomerCode,
                    CustomerName = customer.CustomerName,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Note = customer.Note
                }
            };
            return result;
        }
        public async Task<CustomerModel?> GetCustomerByGuidAsync(Guid entityId)
        {
            CustomerEntity? customer = await Queryable.FirstOrDefaultAsync(x => x.EntityId == entityId);
            if (customer == null)
            {
                return null;
            }
            return new CustomerModel
            {
                EntityId = customer.EntityId,
                TaskName = customer.TaskName,
                CustomerCode = customer.CustomerCode,
                CustomerName = customer.CustomerName,
                Address = customer.Address,
                Phone = customer.Phone,
                Note = customer.Note
            };
        }

        public async Task<MPagedResult<CustomerModel>> GetCustomerPagingAsync(int pageIndex, int pageSize)
        {
            IOrderedQueryable<CustomerEntity> query = Queryable.OrderBy(x => x.TaskName);
            MPagedResult<CustomerModel> response = await GetPagedAsync(query, pageIndex, pageSize,
                x => new CustomerModel
                {
                    EntityId = x.EntityId,
                    TaskName = x.TaskName,
                    CustomerCode = x.CustomerCode,
                    CustomerName = x.CustomerName,
                    Address = x.Address,
                    Phone = x.Phone,
                    Note = x.Note
                });
            return response;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync()
        {
            IQueryable<CustomerEntity> query = Queryable.OrderBy(x => x.TaskName).Select(x => x);
            IEnumerable<CustomerModel> response = await query.Select(x => new CustomerModel
            {
                EntityId = x.EntityId,
                TaskName = x.TaskName,
                CustomerCode = x.CustomerCode,
                CustomerName = x.CustomerName,
                Address = x.Address,
                Phone = x.Phone,
                Note = x.Note
            }).ToListAsync();
            return response;
        }
    }
}
