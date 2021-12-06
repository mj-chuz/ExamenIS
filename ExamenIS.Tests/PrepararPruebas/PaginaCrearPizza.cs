using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;


namespace ExamenIS.Tests.PrepararPruebas
{
  public class PaginaCrearPizza
  {

    public struct PizzaNueva
    {
      public String Masa { get; set; }
      public String TipoSalsa { get; set; }
      public String CantidadQueso { get; set; }
      public String Ingrediente { get; set; }

      public void AgregarDatos()
      {
        this.Masa = "Delgada";
        this.TipoSalsa = "Tomate";
        this.CantidadQueso = "Regular";
      }
    }

    public IWebDriver DriverChrome;
    public String DireccionPaginaCrearPizza = "https://localhost:44336/Pizza/CrearPizza";
    public By SeleccionarMasa = By.Id("TipoMasa");
    public By SeleccionarSalsa = By.XPath("//*[@id='TipoSalsa']");
    public By CantidadQueso = By.Id("CantidadQueso");
    public By Ingrediente = By.XPath("/html/body/div/div/form/div/div[2]/div[3]/div[1]/div/input");
    public By BotonGuardar = By.XPath("/html/body/div/div/form/div/input");

    public PaginaCrearPizza(IWebDriver driverChrome)
    {
      this.DriverChrome = driverChrome;
    }

    public void IniciarPagina()
    {
      DriverChrome.Manage().Window.Maximize();
      DriverChrome.Navigate().GoToUrl(DireccionPaginaCrearPizza);
    }

    public IWebElement CrearPizza()
    {
      PizzaNueva datosPizza = new PizzaNueva();
      datosPizza.AgregarDatos();
      SelectElement seleccionarMasa = new SelectElement(DriverChrome.FindElement(SeleccionarMasa));
      seleccionarMasa.SelectByValue(datosPizza.Masa);
      SelectElement cantidadQueso = new SelectElement(DriverChrome.FindElement(CantidadQueso));
      cantidadQueso.SelectByValue(datosPizza.CantidadQueso);
      SelectElement seleccionarSalsa = new SelectElement(DriverChrome.FindElement(SeleccionarSalsa));
      seleccionarSalsa.SelectByValue(datosPizza.TipoSalsa);
      DriverChrome.FindElement(Ingrediente).Click();
      DriverChrome.FindElement(BotonGuardar).Click();
      By MensajeError = By.XPath("/html/body/div/div/form/div/div[1]/div[1]/div[1]/span");
      IWebElement error = DriverChrome.FindElement(MensajeError);
      return error;
    }


  }
}
