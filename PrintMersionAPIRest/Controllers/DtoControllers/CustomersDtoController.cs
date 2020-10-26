using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.DTOs;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersDtoController : GenericDTOsController<Customer, CustomerDto>
    {
        public CustomersDtoController(IRepository<Customer> Repository, IMapper mapper) : base(Repository, mapper)
        {
        }
    }
}