using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrintMersion.Core.Interfaces
{
   public interface IRepository<T> where T:class,new()
    {
      
        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task Post(T post);

        Task Delete(T post);

        Task Put(T post);

        Task Patch(T post);

        

    }
}
