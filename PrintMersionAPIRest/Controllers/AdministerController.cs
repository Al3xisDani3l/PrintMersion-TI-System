using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Infrastructure.Repositories;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministerController : ControllerBase
    {

        private readonly IAdministerRepository _administerRepository;
        public AdministerController(IAdministerRepository administerRepository )
        {
            _administerRepository = administerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdministers()
        {
            var administers = await _administerRepository.GetAdministers();
            return Ok(administers);
        }

    }
}