using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace ExamenIS.Tests.PrepararPruebas
{
  public class PaginaDomicilio
  {
    public struct NuevoUsuario
    {
      public String Identificacion { get; set; }
      public String Nombre { get; set; }
      public String Telefono { get; set; }
      public String Direccion { get; set; }
      public String Distrito { get; set; }

      public void AgregarDatos()
      {
        this.Identificacion = "118300514";
        this.Nombre = "Andres Medrano";
        this.Telefono = "8888888";
        this.Direccion = "Del Parque de Sabanilla 400 metros oeste, casa amarilla";
        this.Distrito = "Sabanilla";
      }
    }

    public IWebDriver DriverChrome;
    public By Identificacion = By.XPath("//*[@id='Identificacion']");
    public By Nombre = By.XPath("//*[@id='Nombre']");
    public By Telefono = By.Id("Telefono");
    public By Direccion = By.Id("Direccion");
    public By Distrito = By.Id("Distrito");
    public By BotonGuardar = By.XPath("/html/body/div/div/form/div/div/div[2]/input");
    public By TituloVentanaPago = By.XPath("/html/body/div/div/h1");

    public PaginaDomicilio(IWebDriver driverChrome)
    {
      this.DriverChrome = driverChrome;
    }

    public IWebElement IngresarDatos(IWebDriver driveChrome)
    {
      NuevoUsuario datosUsuario = new NuevoUsuario();
      datosUsuario.AgregarDatos();
      driveChrome.FindElement(Identificacion).SendKeys(datosUsuario.Identificacion);
      driveChrome.FindElement(Nombre).SendKeys(datosUsuario.Nombre);
      driveChrome.FindElement(Telefono).SendKeys(datosUsuario.Telefono);
      driveChrome.FindElement(Direccion).SendKeys(datosUsuario.Direccion);
      SelectElement seleccionarDistrito = new SelectElement(driveChrome.FindElement(Distrito));
      seleccionarDistrito.SelectByValue(datosUsuario.Distrito);
      driveChrome.FindElement(BotonGuardar).Click();
      IWebElement tituloPaginaPago = driveChrome.FindElement(TituloVentanaPago);
      return tituloPaginaPago;


    }
  }
}
