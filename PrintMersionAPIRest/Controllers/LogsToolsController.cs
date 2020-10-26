using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsToolsController : GenericController<LogsTools>
    {
        public LogsToolsController(IRepository<LogsTools> Repository, IService<LogsTools> service) : base(Repository, service)
        {
        }
    }
}