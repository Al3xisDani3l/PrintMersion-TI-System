using PrintMersion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrintMersion.Core.Interfaces
{
    public interface IAdministerRepository
    {

        Task<IEnumerable<Administer>> GetAdministers();
    }
}
