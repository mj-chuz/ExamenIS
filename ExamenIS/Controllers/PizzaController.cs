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
      ViewBag.Subtotal = Convert.ToInt32(precioTotal);

      ViewBag.Orden = a;

      return View();
    }


    public ActionResult VentanaPago(String productos, bool necesitaEnvio = false, int precioTotal = 0)
    {
      if (necesitaEnvio) {
        UsuarioModel us = (UsuarioModel)TempData["orden"];
        us.PagoTotal = (int)(us.PagoTotal * 1.13);
        ViewBag.Usuario = us;
        TempData["orden"] = us;
      }
     
      List<String> productosOrdenados = new List<String>();
      String[] listaIngredientes = productos.Split(new[] { "," }, StringSplitOptions.None);
      foreach (String articulo in listaIngredientes)
      {
        if (articulo != "")
        {
          productosOrdenados.Add(articulo);
        }

      }
      ViewBag.Total = precioTotal * 1.13;

      ViewBag.Productos = productosOrdenados;
      
      ViewBag.Envio = necesitaEnvio;
      
      return View();
    }

    [HttpPost]
    public ActionResult VentanaPago()
    {
      String nombreOrden = "";
      string a = "";
      String necesitaEnvio = Request.Form["necesitaEnvio"];
      nombreOrden = Request.Form["nombreTarjeta"];
      a = Request.Form["pagoTotal"];
      bool envio = Convert.ToBoolean(necesitaEnvio);
      if (envio)
      {
        UsuarioModel us = (UsuarioModel)TempData["orden"];
        TempData["orden"] = us;
        
      }else
      {
        nombreOrden = Request.Form["nombreTarjeta"];
        a = Request.Form["pagoTotal"];
      }
      return RedirectToAction("ComprobantePago", "Pizza", new { necesitaEnvio = envio, nombreOrden = nombreOrden, pagoTotal = Convert.ToInt32(a) });
    }

    public ActionResult ComprobantePago(bool necesitaEnvio, String nombreOrden = "", int pagoTotal = 0)
    {
      ViewBag.Envio = necesitaEnvio;
      if (necesitaEnvio) {
        UsuarioModel us = (UsuarioModel)TempData["orden"];
        ViewBag.Usuario = us;
      }
      else
      {
        ViewBag.Nombre = nombreOrden;
        ViewBag.Pago = pagoTotal;
      }
     
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
            ViewBag.Message = ":)";
          }
        }
        TempData["orden"] = usuario;
        return RedirectToAction("VentanaPago", "Pizza", new { productos = usuario.Productos, necesitaEnvio = true });
      }
      catch
      {
        ViewBag.Message = ":(";

        return View(); //si falla se regresa a la vista original pero sin el mensaje
      }
    }

  }
}