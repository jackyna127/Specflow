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

namespace SpecflowBrowser.Pages
{
    public class HomePage: BasePage
    {
        
   
        public HomePage()
            : base()
        {
            webDriver = Browser.Current;
            webDriver.Url = "http://www.store.demoqa.com";
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(secondTimeOut));
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
