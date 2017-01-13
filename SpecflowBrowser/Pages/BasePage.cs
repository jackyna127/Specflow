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
    public abstract class BasePage
    {
        protected static IWebDriver webDriver;
        protected int secondTimeOut;

        public BasePage()
        {
           
            secondTimeOut = 30;
           
        }
        public void InstanceWebDriver()
        {
            
        }
        public void WaitForPageElement(By webElement)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(secondTimeOut));

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(webElement));
            }
            catch (WebDriverTimeoutException)
            {
                //add throw new exception message
            }         
       
        }

        public void SwitchWindow(String windowTitle)
        {
            //string mainWindowHandle = driver.CurrentWindowHandle;
            //ReadOnlyCollection<string> windows = driver.WindowHandles;
            //if (windows.Count > 1)
            //{
            //    foreach (string window in windows)
            //    {
            //        if (window != mainWindowHandle)
            //        {
            //            if (this.driver.SwitchTo().Window(window).Title.Contains(windowTitle))
            //            {
            //                break;
            //            }
            //        }
            //    }
            //}
            //this.driver.Manage().Window.Maximize();
        }


    }
}
