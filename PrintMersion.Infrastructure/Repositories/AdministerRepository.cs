using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using System.Threading.Tasks;
using PrintMersion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PrintMersion.Infrastructure.Repositories
{
 public class AdministerRepository:RepositoryBase<Administer,PrintMersionDBContext>
    {

        public AdministerRepository(PrintMersionDBContext context):base(context)
        {
           
        }

       

       
    }
}
