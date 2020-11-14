using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrintMersion.Web.Models;
using PrintMersion.Infrastructure.ApiClient;
using PrintMersion.Core.Interfaces;
using PrintMersion.Core.Entities;

namespace PrintMersion.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IGlobal _global;
        

        public HomeController(ILogger<HomeController> logger,IGlobal global)
        {
            _logger = logger;
            _global = global;

           



        }

        public IActionResult Index()
        {


           
            return  View();
        }


        public IActionResult ErrorNotFound()
        {
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
