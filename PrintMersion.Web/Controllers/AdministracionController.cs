using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Interfaces;
using PrintMersion.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrintMersion.Infrastructure.Data;



namespace PrintMersion.Web.Controllers
{
    public class AdministracionController : Controller
    {
        public IActionResult Index()
        {

            List<(string, string)> vistas = new List<(string, string)>();

            vistas.Add(("Addresses", "Aministrar direcciones"));
            vistas.Add(("Catalogs", " Administrar catalogos"));
            vistas.Add(("Customers", "Administrar clientes"));
            vistas.Add(("Orders", "Administrar ordenes de pedidos"));
            vistas.Add(("Products", "Administrar productos"));
            vistas.Add(("Tools", "Administrar Herramientas"));
            vistas.Add(("Users", "Administrar usuarios"));

            return  View(vistas);
        }
    }
}