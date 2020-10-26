using PrintMersion.Core.Entities;

namespace PrintMersion.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, Data.PrintMersionDBContext>
    {
        public CustomerRepository(Data.PrintMersionDBContext context) : base(context)
        {

        }
    }
}
