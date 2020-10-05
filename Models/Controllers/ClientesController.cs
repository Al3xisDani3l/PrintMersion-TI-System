using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrintMersion_Models.Entities;

namespace PrintMersion_Models.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController
    {
        private readonly ILogger<ClientesController> _logger;


        public ClientesController(ILogger<ClientesController> logger)
        {

            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return new List<Client>();



        }


    }
}
