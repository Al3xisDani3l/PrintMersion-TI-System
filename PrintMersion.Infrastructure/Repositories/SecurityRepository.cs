using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using PrintMersion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PrintMersion.Infrastructure.Repositories
{
    public class SecurityRepository : RepositoryBase<User, PrintMersionDBContext>, ISecurityRepositor
    {



        public SecurityRepository(PrintMersionDBContext context) : base(context)
        {
        }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            var list = await Get();
            return list.FirstOrDefault(x => x.UserName.ToLowerInvariant() == login.UserName.ToLowerInvariant());
        }

        public async Task RegisterUser(User security)
        {
            await Put(security);
           
        }
    }
}
