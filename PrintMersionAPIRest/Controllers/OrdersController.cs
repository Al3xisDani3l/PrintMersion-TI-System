using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : GenericController<Order>
    {
        public OrdersController(IRepository<Order> Repository, IService<Order> service) : base(Repository, service)
        {
        }
    }
}