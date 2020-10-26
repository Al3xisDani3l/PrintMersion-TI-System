using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IRepository<Product> Repository, IService<Product> service) : base(Repository, service)
        {
        }
    }
}