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

namespace SpecflowBrowser.Pages
{
    public class SearchPage: BasePage
    {
        string searchText = "";
        public SearchPage()
            : base()
        {
            webDriver.Url = "http://www.store.demoqa.com";
        }
        #region Elements
        //By searchInput = By.CssSelector("form.searchform fieldset input[class^=\"search\"]");
        By searchInput = By.Name("s");
        #endregion

        #region Methods
        public void SearchProducts(string productName)
        {
            this.searchText = productName;
            base.WaitForPageElement(searchInput);
            webDriver.FindElement(searchInput).Click();
            webDriver.FindElement(searchInput).Clear();
            webDriver.FindElement(searchInput).SendKeys(productName);
            webDriver.FindElement(searchInput).SendKeys(Keys.Enter);

        }

        public void VerifySearchResult()
        {
            base.WaitForPageElement(By.PartialLinkText(this.searchText));
            true.Equals(webDriver.FindElement(By.PartialLinkText(this.searchText)).Displayed);
        }
        #endregion  
    }
}
