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
      String pizza = "ingrediente";
      List<String> ingredientes = new List<String>();
      String ingredienteAgregado = "";
      for (int ingrediente = 1; ingrediente < 10; ingrediente++)
      {
        ingredienteAgregado = Request.Form[pizza + Convert.ToString(ingrediente)];
        if (ingredienteAgregado != null)
        {
          ingredientes.Add(ingredienteAgregado);
        }

      }
      pizzaCreada.Ingredientes = ingredientes;
      ViewBag.ExitoAlCrear = false;
      try
      {
        if (ModelState.IsValid)
        {
          ViewBag.ExitoAlCrear = true;
          if (ViewBag.ExitoAlCrear)
          {
            ViewBag.Message = "La pizza fue creado con éxito :D";
            ModelState.Clear();
          }
        }
        return View();
      }
      catch
      {
        ViewBag.Message = "Algo salió mal y no fue posible crear la pizza :(";

        return View(); //si falla se regresa a la vista original pero sin el mensaje
      }
    }

    public ActionResult ObtenerMenu()
    {
      PizzaHandler accesoArticulos = new PizzaHandler();
      ViewBag.articulos = accesoArticulos.ObtenerArticulos();
      return View();
    }

    [HttpGet]
    public ActionResult ElegirServicio(String a, String precioTotal)
    {
      ViewBag.Productos = a;
      ViewBag.Precio = precioTotal; 
      return View();
    }

    [HttpPost]
    public ActionResult Recibir()
    {
      String a = Request.Form["productosComprador"];
      String precioTotal = Request.Form["subtotalPrecio"];
      return RedirectToAction("ElegirServicio", "Pizza", new {a = a, precioTotal = precioTotal});    
    }

    public ActionResult PedirServicioDomicilio(String a, String precioTotal)
    {
      
      return View();
    }


    public ActionResult VentanaPago()
    {
      return View();
    }

    [HttpPost]
    public ActionResult PedirServicioDomicilio(UsuarioModel usuario)
    {
      ViewBag.ExitoAlCrear = false;
      try
      {
        if (ModelState.IsValid)
        {
          ViewBag.ExitoAlCrear = true;
          if (ViewBag.ExitoAlCrear)
          {
            ViewBag.Message = ":D";
            ModelState.Clear();
          }
        }
        return View();
      }
      catch
      {
        ViewBag.Message = ":(";

        return View(); //si falla se regresa a la vista original pero sin el mensaje
      }
    }

  }
}