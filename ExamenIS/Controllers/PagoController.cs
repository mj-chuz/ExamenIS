using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ExamenIS.Models;

namespace ExamenIS.Controllers
{
  public class PagoController : Controller
  {
    public ActionResult VentanaPago(String productos, bool necesitaEnvio = false, int precioTotal = 0)
    {
      if (necesitaEnvio)
      {
        UsuarioModel usuarioOrden = (UsuarioModel)TempData["orden"];
        usuarioOrden.PagoTotal = (usuarioOrden.PagoTotal * 1.13)+2500;
        ViewBag.Usuario = usuarioOrden;
        TempData["orden"] = usuarioOrden;
      }
      else
      {
        ViewBag.Total = precioTotal * 1.13;
      }
     
      ViewBag.Productos = this.ObtenerProductosOrden(productos);
      ViewBag.Envio = necesitaEnvio;
      return View();
    }

    public List<String> ObtenerProductosOrden(String productosOrden)
    {
      List<String> productosOrdenados = new List<String>();
      String[] listaIngredientes = productosOrden.Split(new[] { "," }, StringSplitOptions.None);
      foreach (String articulo in listaIngredientes)
      {
        if (articulo != "")
        {
          productosOrdenados.Add(articulo);
        }
      }
      return productosOrdenados;
    }

    [HttpPost]
    public ActionResult VentanaPago()
    {
      String nombreOrden = "";
      string pagoTotal = "0";
      String necesitaEnvio = Request.Form["necesitaEnvio"];
      bool envio = Convert.ToBoolean(necesitaEnvio);
      if (envio)
      {
        UsuarioModel usuarioOrden = (UsuarioModel)TempData["orden"];
        TempData["orden"] = usuarioOrden;
      }
      else
      {
        nombreOrden = Request.Form["nombreTarjeta"];
        pagoTotal = Request.Form["pagoTotal"];
      }
      return RedirectToAction("ComprobantePago", "Pago", new { necesitaEnvio = envio, nombreOrden = nombreOrden, pagoTotal = Convert.ToDouble(pagoTotal) });
    }


    public ActionResult ComprobantePago(bool necesitaEnvio, String nombreOrden = "", Double pagoTotal = 0)
    {
      ViewBag.Envio = necesitaEnvio;
      if (necesitaEnvio)
      {
        UsuarioModel usuarioOrden = (UsuarioModel)TempData["orden"];
        ViewBag.Usuario = usuarioOrden;
      }
      else
      {
        ViewBag.Nombre = nombreOrden;
        ViewBag.Pago = pagoTotal;
      }
      return View();
    }
  }
}