using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using ExamenIS.Tests.PrepararPruebas;

namespace ExamenIS.Tests.PruebasAutomatizadas
{
  [TestClass]
  public class PruebaServicioDomicilio
  {
    public PaginaMenu AccederPaginaMenu;

    public PaginaServicios AccederPaginaServicios;

    public PaginaDomicilio AccederPaginaDomicilio;

    IWebDriver ChromeDriver;

    public PruebaServicioDomicilio()
    {
      ChromeDriver = new ChromeDriver();
      AccederPaginaMenu = new PaginaMenu(ChromeDriver);
      AccederPaginaServicios = new PaginaServicios(ChromeDriver);
      AccederPaginaDomicilio = new PaginaDomicilio(ChromeDriver);
    }

    [TestMethod]
    public void PedirPizzaDomicilio_EP()
    {
      AccederPaginaMenu.IniciarPagina();
      ChromeDriver = AccederPaginaMenu.ComprarProducto();
      ChromeDriver = AccederPaginaServicios.IngresarPaginaDomicilio(ChromeDriver);
      IWebElement titulo = AccederPaginaDomicilio.IngresarDatos(ChromeDriver);
      Assert.AreEqual(titulo.Text, "Ventana de pago");
      ChromeDriver.Quit();
    }
  }
}
