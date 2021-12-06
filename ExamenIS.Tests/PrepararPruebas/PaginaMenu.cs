using OpenQA.Selenium;
using System;

namespace ExamenIS.Tests.PrepararPruebas
{
  public class PaginaMenu
  {
    public IWebDriver DriverChrome;
    public String DireccionPaginaMenu = "https://localhost:44336/Menu/ObtenerMenu";
    public By BotonCombo = By.XPath("/html/body/div/div/div/div[1]/div[1]/div/div/div[2]/button");
    public By BotonPagar = By.XPath("/html/body/div/div/div/div[2]/div/div/form/input[2]");

    public PaginaMenu(IWebDriver driverChrome)
    {
      this.DriverChrome = driverChrome;
    }

    public void IniciarPagina()
    {
      DriverChrome.Manage().Window.Maximize();
      DriverChrome.Navigate().GoToUrl(DireccionPaginaMenu);
    }

    public IWebDriver ComprarProducto()
    {
      DriverChrome.FindElement(BotonCombo).Click();
      DriverChrome.FindElement(BotonPagar).Click();
      return DriverChrome;
    }

  }
}
