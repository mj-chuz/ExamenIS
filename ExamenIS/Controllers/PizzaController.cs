using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ExamenIS.Models;
namespace ExamenIS.Controllers
{
  public class PizzaController : Controller
  {
    [HttpGet]
    public ActionResult CrearPizza()
    {
      return View();
    }
    [HttpPost]
    public ActionResult CrearPizza(PizzaModel pizzaCreada)
    {
      String valorIngrediente = "ingrediente";
      int contadorIngredientes = 0;
      List<String> ingredientesAgregados = new List<String>();
      String ingredienteAgregado = "";
      for (int ingrediente = 1; ingrediente < 10; ingrediente++)
      {
        ingredienteAgregado = Request.Form[valorIngrediente + Convert.ToString(ingrediente)];
        if (ingredienteAgregado != null)
        {
          ingredientesAgregados.Add(ingredienteAgregado);
          contadorIngredientes++;
        }

      }
      pizzaCreada.Ingredientes = ingredientesAgregados;
      pizzaCreada = this.CalcularPrecio(pizzaCreada, contadorIngredientes);

      ViewBag.ExitoAlCrear = false;
      try
      {
        if (ModelState.IsValid)
        {
          return RedirectToAction("ObtenerMenu", "Menu", new { nombrePizza = pizzaCreada.Nombre, precio = pizzaCreada.Precio });
        }
      }
      catch
      {
        ViewBag.Message = "Algo salió mal y no fue posible crear la pizza :(";
      }
      return View();
    }
    public PizzaModel CalcularPrecio(PizzaModel pizzaCreada, int cantidadIngredientes)
    {

      if (pizzaCreada.Tamano == "Grande")
      {
        pizzaCreada.Precio += 2000;
      }
      pizzaCreada.Precio += (cantidadIngredientes * 1000);

      if (pizzaCreada.CantidadQueso == "Extra")
      {
        pizzaCreada.Precio += 1000;
      }
      return pizzaCreada;
    }

  }
}