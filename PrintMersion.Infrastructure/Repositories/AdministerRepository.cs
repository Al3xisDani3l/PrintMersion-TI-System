using PrintMersion.Core.Entities;
using PrintMersion.Infrastructure.Data;

namespace PrintMersion.Infrastructure.Repositories
{
    public class AdministerRepository : RepositoryBase<Administer, PrintMersionDBContext>
    {

        public AdministerRepository(PrintMersionDBContext context) : base(context)
        {

        }




    }
}
