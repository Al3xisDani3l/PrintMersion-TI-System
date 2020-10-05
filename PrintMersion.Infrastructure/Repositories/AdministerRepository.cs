using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using System.Threading.Tasks;

namespace PrintMersion.Infrastructure.Repositories
{
 public class AdministerRepository:IAdministerRepository
    {

        public async Task<IEnumerable<Administer>> GetAdministers()
        {
            var administer = Enumerable.Range(1, 10).Select(x => new Administer
            {
                Id = x,
                HiringDate = DateTime.Now,
                Name = $"Soy el numero : {x}",
                Image = $"https://misapis.com/{x}"        
            }) ;

            await Task.Delay(10);

            return administer;
        }
       
    }
}
