using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.DTOs;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDtoController : GenericDTOsController<Product, ProductDto>
    {
        public ProductsDtoController(IRepository<Product> Repository, IMapper mapper) : base(Repository, mapper)
        {
        }
    }
}