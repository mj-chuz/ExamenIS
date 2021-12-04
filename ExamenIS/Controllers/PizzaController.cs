﻿using System;
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
  }
}