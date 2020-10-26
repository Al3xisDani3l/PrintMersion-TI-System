using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Api.Responses;
using PrintMersion.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintMersion.Api.Controllers
{

    [ApiController]
    public class GenericDTOsController<TEntity, TEntityDto> : ControllerBase, IController<TEntityDto> where TEntity : class, IEntity, new() where TEntityDto : class, IEntity, new()
    {

        private readonly IRepository<TEntity> _Repository;
        private readonly IMapper _mapper;
        public GenericDTOsController(IRepository<TEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Repository.Delete(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _Repository.Get();
            var resultMapper = _mapper.Map<IEnumerable<TEntityDto>>(result);
            var response = new ApiResponse<IEnumerable<TEntityDto>>(resultMapper);

            return Ok(response);

        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _Repository.Get(id);
            var resultMapper = _mapper.Map<TEntityDto>(result);
            var response = new ApiResponse<TEntityDto>(resultMapper);

            return Ok(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntityDto administer)
        {
            var resultMapper = _mapper.Map<TEntity>(administer);
            var result = await _Repository.Post(resultMapper);
            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(TEntityDto entity)
        {
            var resultMapper = _mapper.Map<TEntity>(entity);

            var result = await _Repository.Put(resultMapper);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}