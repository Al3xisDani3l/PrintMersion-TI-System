using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Api.Responses;
using PrintMersion.Core.Interfaces;


namespace PrintMersion.Api.Controllers
{
    [ApiController]
    public class GenericController<TEntity> : ControllerBase where TEntity:class,new()
    {

        private readonly IRepository<TEntity> _Repository;
        private readonly IService<TEntity> _service;
        public GenericController(IRepository<TEntity> Repository, IService<TEntity> service)
        {
            _Repository = Repository;
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            
            var result = await _Repository.Get();
            var response = new ApiResponse<IEnumerable<TEntity>>(result);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {



            var result = await _Repository.Get(id);
            if (_service.ExecuteAllValidator(result,Core.Enumerations.Operation.GetId))
            {
                var response = new ApiResponse<TEntity>(result);

                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
            

           
        }

        [HttpPost]
        public virtual async Task<IActionResult> post(TEntity entity)
        {
            if (_service.ExecuteAllValidator(entity, Core.Enumerations.Operation.Post)) 
            {
                await _Repository.Post(entity);
               
            }
            else
            {

            }
            var response = new ApiResponse<TEntity>(entity);


            _service.ClearResults();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Repository.Delete(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);


        }
        [HttpPut]
        public async Task<IActionResult> Put(TEntity entity)
        {
            var result = await _Repository.Put(entity);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

       

    }
}
