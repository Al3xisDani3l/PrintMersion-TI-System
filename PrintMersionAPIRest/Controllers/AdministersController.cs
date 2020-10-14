using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Infrastructure.Repositories;
using PrintMersion.Core.Interfaces;
using PrintMersion.Core.Entities;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministersController : GenericController<Administer>
    {


        //    private readonly IRepository<Administer> _administerRepository;
        public AdministersController(IRepository<Administer> administerRepository,IService<Administer> service):base(administerRepository,service)
        {
            
        }

        //    [HttpGet]
        //    public async Task<IActionResult> Get()
        //    {
        //        var administers = await _administerRepository.Get();
        //        return Ok(administers);
        //    }

        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> Get(int id)
        //    {
        //        var adm = await _administerRepository.Get(id);
        //        return Ok(adm);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> post(Administer administer)
        //    {
        //        await _administerRepository.Post(administer);
        //        return Ok(administer);
        //    }

    }
}

