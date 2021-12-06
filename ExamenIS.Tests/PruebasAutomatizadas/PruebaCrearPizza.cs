using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using ExamenIS.Tests.PrepararPruebas;

namespace ExamenIS.Tests.PruebasAutomatizadas
{
  [TestClass]
  public class PruebaCrearPizza
  {
    public PaginaCrearPizza AccederPaginaCrearPizza;
    IWebDriver ChromeDriver;

    public PruebaCrearPizza()
    {
      ChromeDriver = new ChromeDriver();
      AccederPaginaCrearPizza = new PaginaCrearPizza(ChromeDriver);
    }

    [TestMethod]
    public void CrearPizzaSinTamano_CP()
    {
      AccederPaginaCrearPizza.IniciarPagina();
      IWebElement mensajeError = AccederPaginaCrearPizza.CrearPizza();
      Assert.AreEqual("Es necesario que indique el tamaño de la pizza", mensajeError.Text);
      ChromeDriver.Quit();
    }
  }
}
