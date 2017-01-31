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
    public class LoginPage: BasePage
    {

        public LoginPage()
            : base()
        {
            
        }

        #region Elements
        By userName = By.Id("log");
        By passWord = By.Id("pwd");
        By loginButton = By.Id("login");      
        By logoutLink = By.LinkText("Log out");
        By loginSuccessMessage = By.PartialLinkText("Howdy");

        #endregion

        #region Methods
        public void EnterUserName(string username)
        {

            base.WaitForPageElement(loginButton);
            webDriver.FindElement(userName).SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            webDriver.FindElement(passWord).SendKeys(password);
        }
        public void ClickLoginButton()
        {
           webDriver.FindElement(loginButton).Click();
        }

        public void ClickLogoutLink()
        {
            base.WaitForPageElement(logoutLink);
             webDriver.FindElement(logoutLink).Click();
        }
        public void VerifyLoginMessageDisplay()
        {
            base.WaitForPageElement(loginSuccessMessage);
            true.Equals(webDriver.FindElement(loginSuccessMessage).Displayed);
        }
        public void VerifyLogoutMessageDisplay()
        {
            base.WaitForPageElement(loginButton);
            true.Equals(webDriver.FindElement(loginButton).Displayed);
        }

          #endregion

    }
}
