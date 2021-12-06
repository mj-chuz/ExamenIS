using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ExamenIS.Tests.PrepararPruebas
{

  public class PaginaPago
  {

    public IWebDriver DriverChrome;
    public By NumeroTarjeta = By.Id("numeroTarjeta");
    public By NombreTarjeta = By.Id("nombreTarjeta");
    public By Mes = By.Id("mes-expiracion");
    public By Anno = By.Id("anho-expiracion");
    public By CVC = By.Id("cvc");
    public By BotonGuardar = By.Id("boton-pagar");
    public By TituloVentanaPago = By.XPath("/html/body/div/div/h1");
    public By TituloComprobante = By.XPath("/html/body/div/div/h2");
    public struct TarjetaNueva
    {
      public String NumeroMalo { get; set; }
      public String Nombre { get; set; }
      public String Mes { get; set; }
      public String Anno { get; set; }
      public String CVC { get; set; }

      public void AgregarDatos()
      {
        this.NumeroMalo = "123456a789a1234a";
        this.Nombre = "Pedrito Campos";
        this.Mes = "3";
        this.Anno = "2022";
        this.CVC = "123";
      }
    }

    public PaginaPago(IWebDriver driverChrome)
    {
      this.DriverChrome = driverChrome;
    }

    public IWebElement IngresarMalDatosTarjeta(IWebDriver driveChrome)
    {


      TarjetaNueva datosTarjeta = new TarjetaNueva();
      datosTarjeta.AgregarDatos();
      driveChrome.FindElement(NumeroTarjeta).SendKeys(datosTarjeta.NumeroMalo);
      driveChrome.FindElement(NombreTarjeta).SendKeys(datosTarjeta.Nombre);
      driveChrome.FindElement(CVC).SendKeys(datosTarjeta.CVC);
      SelectElement seleccionarMes = new SelectElement(driveChrome.FindElement(Mes));
      seleccionarMes.SelectByValue(datosTarjeta.Mes);
      SelectElement seleccionarAnno = new SelectElement(driveChrome.FindElement(Anno));
      seleccionarAnno.SelectByValue(datosTarjeta.Anno);
      driveChrome.FindElement(BotonGuardar).Click();
      IWebElement tituloPaginaPago = driveChrome.FindElement(TituloVentanaPago);
      return tituloPaginaPago;

    }

    public IWebElement IngresarDatosTarjeta(IWebDriver driveChrome)
    {


      TarjetaNueva datosTarjeta = new TarjetaNueva();
      datosTarjeta.AgregarDatos();
      driveChrome.FindElement(NumeroTarjeta).SendKeys("1234567789712344");
      driveChrome.FindElement(NombreTarjeta).SendKeys(datosTarjeta.Nombre);
      driveChrome.FindElement(CVC).SendKeys(datosTarjeta.CVC);
      SelectElement seleccionarMes = new SelectElement(driveChrome.FindElement(Mes));
      seleccionarMes.SelectByValue(datosTarjeta.Mes);
      SelectElement seleccionarAnno = new SelectElement(driveChrome.FindElement(Anno));
      seleccionarAnno.SelectByValue(datosTarjeta.Anno);
      driveChrome.FindElement(BotonGuardar).Click();
      IWebElement tituloPaginaPago = driveChrome.FindElement(TituloComprobante);
      return tituloPaginaPago;

    }

  }
}
