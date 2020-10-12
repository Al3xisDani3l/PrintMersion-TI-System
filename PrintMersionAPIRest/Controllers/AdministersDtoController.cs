using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Infrastructure.Repositories;
using PrintMersion.Core.Interfaces;
using PrintMersion.Core.Entities;
using PrintMersion.Core.DTOs;
using AutoMapper;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministersDtoController : GenericDTOsController<Administer,AdministerDto>
    {
        public AdministersDtoController(IRepository<Administer> repository,IMapper mapper) : base(repository, mapper)
        {

        }
    }
}