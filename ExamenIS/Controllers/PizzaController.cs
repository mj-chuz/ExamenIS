 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenIS.Models;
using ExamenIS.Handlers;
namespace ExamenIS.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        [HttpGet]
        public ActionResult CrearPizza()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearPizza(PizzaModel pizzaCreada)
        {
          return View();
        }
  }
}