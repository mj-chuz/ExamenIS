using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ExamenIS.Tests.PrepararPruebas;
namespace ExamenIS.Tests.PruebasAutomatizadas
{
  [TestClass]
  public class PruebaRetiraEnRestaurante
  {
    public PaginaMenu AccederPaginaMenu;

    public PaginaServicios AccederPaginaServicios;

    public PaginaPago AccederPaginaPago;

    IWebDriver ChromeDriver;

    public PruebaRetiraEnRestaurante()
    {
      ChromeDriver = new ChromeDriver();
      AccederPaginaMenu = new PaginaMenu(ChromeDriver);
      AccederPaginaServicios = new PaginaServicios(ChromeDriver);
      AccederPaginaPago = new PaginaPago(ChromeDriver);
    }
    [TestMethod]
    public void IngresarMalTarjeta_VP()
    {
      AccederPaginaMenu.IniciarPagina();
      ChromeDriver = AccederPaginaMenu.ComprarProducto();
      ChromeDriver = AccederPaginaServicios.IngresarPaginaRetirar(ChromeDriver);
      IWebElement titulo = AccederPaginaPago.IngresarMalDatosTarjeta(ChromeDriver);
      Assert.AreEqual(titulo.Text, "Ventana de pago");
      ChromeDriver.Quit();
    }

    [TestMethod]
    public void IngresarDatosCorrectos()
    {
      AccederPaginaMenu.IniciarPagina();
      ChromeDriver = AccederPaginaMenu.ComprarProducto();
      ChromeDriver = AccederPaginaServicios.IngresarPaginaRetirar(ChromeDriver);
      IWebElement titulo = AccederPaginaPago.IngresarDatosTarjeta(ChromeDriver);
      Assert.AreEqual(titulo.Text, "Detalles de la compra");
      ChromeDriver.Quit();
    }


  }
}
