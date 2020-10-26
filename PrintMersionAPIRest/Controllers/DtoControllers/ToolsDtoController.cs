using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.DTOs;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsDtoController : GenericDTOsController<Tool, ToolDto>
    {
        public ToolsDtoController(IRepository<Tool> Repository, IMapper mapper) : base(Repository, mapper)
        {
        }
    }
}