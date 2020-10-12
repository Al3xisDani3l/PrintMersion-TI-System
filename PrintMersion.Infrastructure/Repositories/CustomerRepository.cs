using System;
using System.Collections.Generic;
using System.Text;
using PrintMersion.Core.Entities;

namespace PrintMersion.Infrastructure.Repositories
{
  public class CustomerRepository:RepositoryBase<Customer, Data.PrintMersionDBContext>
    {
        public CustomerRepository(Data.PrintMersionDBContext context) : base(context)
        {

        }
    }
}
