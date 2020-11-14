using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : GenericController<Address>
    {
        public AddressController(IRepository<Address> Repository, IService<Address> service) : base(Repository, service)
        {
        }
    }
}