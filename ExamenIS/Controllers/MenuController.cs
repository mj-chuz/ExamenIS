using System;
using System.Web.Mvc;
using ExamenIS.Handlers;

namespace ExamenIS.Controllers
{
  public class MenuController : Controller
  {
    public ActionResult ObtenerMenu(String nombrePizza = "", int precio = 0)
    {
      ViewBag.PizzaPersonalizada = nombrePizza;
      ViewBag.PrecioPersonalizado = precio;
      ArticulosHandler accesoArticulos = new ArticulosHandler();
      ViewBag.articulos = accesoArticulos.ObtenerArticulos();
      return View();
    }

    [HttpGet]
    public ActionResult ElegirServicio(String productosOrdenados, String subtotal)
    {
      ViewBag.Productos = productosOrdenados;
      ViewBag.Precio = subtotal;
      return View();
    }

    [HttpPost]
    public ActionResult Recibir()
    {
      String productosOrdenados = Request.Form["productosComprados"];
      String subtotal = Request.Form["subtotalPrecio"];
      return RedirectToAction("ElegirServicio", "Menu", new { productosOrdenados = productosOrdenados, subtotal = subtotal });
    }
  }
}