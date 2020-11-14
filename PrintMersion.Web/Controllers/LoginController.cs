using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Infrastructure.ApiClient;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Web.Controllers
{
    public class LoginController : Controller
    {

        IGlobal _global;

        public LoginController(IGlobal global)
        {
            _global = global;
        }


        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> GetToken([Bind("UserName","Password")] UserLogin login)
        {

            if (ModelState.IsValid && login != null)
            {
                _global.CurrentToken =await ClientToken.GetToken(login);

            }

            if (_global.CurrentToken != null)
            {
                return RedirectToAction("Index","Administracion");
            }
            else
            {
                return NotFound();
            }

           





        }

       
    }
}