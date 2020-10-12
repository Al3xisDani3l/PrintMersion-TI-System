using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Interfaces;
using System.Collections.Generic;


namespace PrintMersion.Api.Controllers
{
   
    [ApiController]
    public class GenericDTOsController<TEntity,TEntityDto> : ControllerBase where TEntity:class,new() where TEntityDto :class,new()
    {

        private readonly IRepository<TEntity> _Repository;
        private readonly IMapper _mapper;
        public GenericDTOsController(IRepository<TEntity> Repository,IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _Repository.Get();
            var resultMapper = _mapper.Map<IEnumerable<TEntityDto>>(result);

            return Ok(resultMapper);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _Repository.Get(id);
            var resultMapper = _mapper.Map<TEntityDto>(result);
            return Ok(resultMapper);
        }

        [HttpPost]
        public virtual async Task<IActionResult> post(TEntityDto administer)
        {
            var resultMapper = _mapper.Map<TEntity>(administer);
            await _Repository.Post(resultMapper);
            return Ok(administer);
        }

    }
}