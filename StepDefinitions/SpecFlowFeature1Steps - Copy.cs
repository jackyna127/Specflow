using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecflowBrowser.Utilities;


namespace SpecflowBrowser
{
    [Binding]
    public sealed class StepDefinition1
    {

        [Binding]
        public class LogIn_Steps
        {   
            
            public IWebDriver driver;
            //public static IWebDriver driver;
            int intSecondTimeOut = 20;
            [Given(@"User is at the Home Page")]
            public void GivenUserIsAtTheHomePage()
            {
                driver = new FirefoxDriver();
                driver.Url = "http://www.store.demoqa.com";
               
            }
            [BeforeScenario]
            public void BeforeScenarios()
            {
                System.Console.WriteLine("Before scenarios.");
            }

            [AfterScenario]
            public void AfterScenarios()
            {
                System.Console.WriteLine("After scenarios.");
            }
            [Given(@"Navigate to LogIn Page")]
            public void GivenNavigateToLogInPage()
            {
                 
                 driver.FindElement(By.XPath(".//*[@id='account']/a")).Click();
            }
            //[When(@"User enter (.*) and (.*)")]
            [When(@"User enter username and password")]
            public void WhenUserEnterAnd(Table table)
            {
                WaitClass.WaitForElementLoad(driver, By.Id("log"), intSecondTimeOut);
                Userinfo oUserinfo = table.CreateInstance<Userinfo>();
                driver.FindElement(By.Id("log")).SendKeys(oUserinfo.username);
                driver.FindElement(By.Id("pwd")).SendKeys(oUserinfo.password);
            }

            [When(@"Click on the LogIn button")]
            public void WhenClickOnTheLogInButton()
            {
                
                driver.FindElement(By.Id("login")).Click();                
            }

            [When(@"User LogOut from the Application")]
            public void WhenUserLogOutFromTheApplication()
            {
                driver = (IWebDriver)FeatureContext.Current.Get<IWebDriver>("handle");
                WaitClass.WaitForElementLoad(driver, By.LinkText("(Logout)"), intSecondTimeOut);
                driver.FindElement(By.LinkText("(Logout)")).Click();
            }

            [Then(@"Successful LogIN message should display")]
            public void ThenSuccessfulLogINMessageShouldDisplay()
            {
                //This Checks that if the LogOut button is displayed
                WaitClass.WaitForElementLoad(driver, By.PartialLinkText("Howdy"), intSecondTimeOut);
                true.Equals(driver.FindElement(By.PartialLinkText("Howdy")).Displayed);
               // ScenarioContext.Current.Add("Handle", driver); 
               // ScenarioContext.Current["InfoString"] = "Just test the string";
                ScenarioContext.Current.Add("InfoString", "Just test the string pass");
                string s = "";
                s = ScenarioContext.Current.Get<String>("InfoString");
                FeatureContext.Current.Add("handle", driver);

            }

            [Then(@"Successful LogOut message should display")]
            public void ThenSuccessfulLogOutMessageShouldDisplay()
            {             
                
                
                WaitClass.WaitForElementLoad(driver, By.Id("login"), intSecondTimeOut);
                true.Equals(driver.FindElement(By.Id("login")).Displayed);
                
            }
        }
        public class Userinfo
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        
    }
}
