using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace SpecflowBrowser.Pages
{
    public class HomePage: BasePage
    {
        
   
        public HomePage()
            : base()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("../../packages/Selenium.Firefox.WebDriver.0.13.0/driver");
            webDriver = new FirefoxDriver(service, new FirefoxOptions(), TimeSpan.FromSeconds(180));//new FirefoxDriver();
            webDriver.Url = "http://www.store.demoqa.com";
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
        }
        #region Elements
        By myAccount = By.XPath(".//*[@id='account']/a");
    
        #endregion

        #region Methods
        public void GotoLoginPage()
        {
            webDriver.FindElement(myAccount).Click();
        }
        #endregion
    }
}
