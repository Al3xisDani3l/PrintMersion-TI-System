using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : GenericController<Tool>
    {
        public ToolsController(IRepository<Tool> Repository, IService<Tool> service) : base(Repository, service)
        {
        }
    }
}