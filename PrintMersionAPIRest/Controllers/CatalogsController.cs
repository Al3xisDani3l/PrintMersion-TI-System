using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : GenericController<Catalog>
    {
        public CatalogsController(IRepository<Catalog> Repository, IService<Catalog> service) : base(Repository, service)
        {
        }
    }
}