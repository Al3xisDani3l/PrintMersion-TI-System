using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.DTOs;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministersDtoController : GenericDTOsController<Administer, AdministerDto>
    {
        public AdministersDtoController(IRepository<Administer> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}