using Microsoft.AspNetCore.Mvc;
using PrintMersion.Api.Responses;
using PrintMersion.Core.Exceptions;
using PrintMersion.Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PrintMersion.Api.Controllers
{
    [ApiController]
    public class GenericController<TEntity> : ControllerBase, IController<TEntity> where TEntity : class, IEntity, new()
    {

        private readonly IRepository<TEntity> _Repository;
        private readonly IService<TEntity> _service;
        public GenericController(IRepository<TEntity> Repository, IService<TEntity> service)
        {
            _Repository = Repository;
            _service = service;
        }

        /// <summary>
        /// Retrieve all <see cref="TEntity"/>
        /// </summary>
        /// <returns></returns>
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
            if (_service.ExecuteAllValidator(result, Core.Enumerations.Operation.GetId))
            {
                var response = new ApiResponse<TEntity>(result);


                return Ok(response);
            }
            else
            {
                throw new BusisnessException($"Ningun usuario con el Id : {id}") { Details = _service.Disapprobed, Status = (int)HttpStatusCode.NotFound };
            }



        }
        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntity entity)
        {
            if (_service.ExecuteAllValidator(entity, Core.Enumerations.Operation.Post))
            {
               var result = await _Repository.Post(entity);
                var response = new ApiResponse<bool>(result);

                _service.ClearResults();
                return Ok(response);
            }
            else
            {
                throw new BusisnessException("Esto es una Prueba") { Details = _service.Disapprobed, Status = (int)HttpStatusCode.BadRequest };
            }

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
