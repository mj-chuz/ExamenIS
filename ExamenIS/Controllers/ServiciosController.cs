using System;
using System.Web.Mvc;
using ExamenIS.Models;

namespace ExamenIS.Controllers
{
  public class ServiciosController : Controller
  {
    public ActionResult PedirServicioDomicilio(String productosOrdenados, String precioTotal)
    {
      ViewBag.Subtotal = Convert.ToInt32(precioTotal);
      ViewBag.Orden = productosOrdenados;
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
          TempData["orden"] = usuario;
          return RedirectToAction("VentanaPago", "Pago", new { productos = usuario.Productos, necesitaEnvio = true });
        }
      }
      catch
      {
        ViewBag.Message = "Algo salió mal, no se realizó la orden";
      }
      return View();
    }
  }
}