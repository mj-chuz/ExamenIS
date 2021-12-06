using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ExamenIS.Tests.PrepararPruebas
{
  public class PaginaServicios
  {
    public IWebDriver DriverChrome;
    public By BotonDomicilio = By.XPath("/html/body/div/div/div/div[1]/div/div/a");
    public By BotonRetirar = By.XPath("/html/body/div/div/div/div[2]/div/div/a");

    public PaginaServicios(IWebDriver driverChrome)
    {
      this.DriverChrome = driverChrome;
    }

    public IWebDriver IngresarPaginaDomicilio(IWebDriver driverChrome)
    {
      driverChrome.FindElement(BotonDomicilio).Click();
      return driverChrome;
    }

    public IWebDriver IngresarPaginaRetirar(IWebDriver driverChrome)
    {
      driverChrome.FindElement(BotonRetirar).Click();
      return driverChrome;
    }

  }
}
