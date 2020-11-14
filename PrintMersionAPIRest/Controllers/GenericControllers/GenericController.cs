using Microsoft.AspNetCore.Mvc;
using PrintMersion.Api.Responses;
using PrintMersion.Core.Exceptions;
using PrintMersion.Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


namespace PrintMersion.Api.Controllers
{
    /// <summary>
    /// Clase generica base que contiene toda la logica de interaccion de las entidades del negocio de la API PrintMersion.
    /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
    /// </summary>
    /// <typeparam name="TEntity">Entidad de negocio, esta debe ser una clase y poder ser instanciada, ademas implementar la interfaz <see cref="IEntity"/>.</typeparam>
    [Authorize]
    [ApiController]
    public class GenericController<TEntity> : ControllerBase, IController<TEntity> where TEntity : class, new()
    {

        internal readonly IRepository<TEntity> _Repository;
        internal readonly IService<TEntity> _service;

        /// <summary>
        /// Clase generica base que contiene toda la logica de interaccion de las entidades del negocio de la API PrintMersion.
        /// </summary>
        /// <param name="Repository">Contiene la logica y conexion a la base de datos</param>
        /// <param name="service">Contiene servicios para la comprobacion de las correctas especificaciones y restricciones delas entidades</param>
        public GenericController(IRepository<TEntity> Repository, IService<TEntity> service)
        {
            _Repository = Repository;
            _service = service;

            
        }

        /// <summary>
        /// Obtiene toda la informacion solicitada a la API de una entidad en concreto.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {

            var result = await _Repository.Get();
            var lis = result.ToList();
            var response = new ApiResponse(lis);

            return Ok(response);
        }

        /// <summary>
        /// Obtiene la informacion de una entidad por su Id.
        /// </summary>
        /// <param name="id">Numero unico de identificacion para cada Entidad.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {



            var result = await _Repository.Get(id);
            if (_service.ExecuteAllValidator(result, Core.Enumerations.Operation.GetId))
            {
                var response = new ApiResponse(result);


                return Ok(response);
            }
            else
            {
                throw new BusisnessException($"Ningun usuario con el Id : {id}") { Details = _service.Disapprobed, Status = (int)HttpStatusCode.NotFound };
            }



        }

        /// <summary>
        /// Agrega una entidad nueva a la coleccion correspondiente.
        /// </summary>
        /// <param name="entity">Entidad a agregar</param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntity entity)
        {
            if (_service.ExecuteAllValidator(entity, Core.Enumerations.Operation.Post))
            {
               var result = await _Repository.Post(entity);
                var response = new ApiResponse(result);

                _service.ClearResults();
                return Ok(response);
            }
            else
            {
                throw new BusisnessException() { Details = _service.Disapprobed, Status = (int)HttpStatusCode.BadRequest };
            }

        }

        /// <summary>
        /// Elimina una entidad por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _Repository.Get(id);
            if (_service.ExecuteAllValidator(result, Core.Enumerations.Operation.Delete))
            {
                var res = await _Repository.Delete(((IEntity)result).Id);
                var response = new ApiResponse(res);

            return Ok(response);
            }
            else
            {
                throw new BusisnessException() { Details = _service.Disapprobed, Status = (int)HttpStatusCode.BadRequest };
            }


        }

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task<IActionResult> Put(TEntity entity)
        {

            if (_service.ExecuteAllValidator(entity, Core.Enumerations.Operation.Put))
            {
                var result = await _Repository.Put(entity);
            var response = new ApiResponse(result);
            return Ok(response);
            }
            else
            {
                throw new BusisnessException() { Details = _service.Disapprobed, Status = (int)HttpStatusCode.BadRequest };
            }
        }



    }
}
