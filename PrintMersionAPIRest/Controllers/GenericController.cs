using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Interfaces;


namespace PrintMersion.Api.Controllers
{
    [ApiController]
    public class GenericController<TEntity> : ControllerBase where TEntity:class,new()
    {

        private readonly IRepository<TEntity> _Repository;
        public GenericController(IRepository<TEntity> Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _Repository.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var adm = await _Repository.Get(id);
            return Ok(adm);
        }

        [HttpPost]
        public virtual async Task<IActionResult> post(TEntity administer)
        {
            await _Repository.Post(administer);
            return Ok(administer);
        }

    }
}
