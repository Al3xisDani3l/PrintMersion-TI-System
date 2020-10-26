using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.DTOs;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersDtoController : GenericDTOsController<Order, OrderDto>
    {
        public OrdersDtoController(IRepository<Order> Repository, IMapper mapper) : base(Repository, mapper)
        {
        }
    }
}