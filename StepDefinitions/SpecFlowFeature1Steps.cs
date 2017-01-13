using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecflowBrowser.Pages;


namespace SpecflowBrowser
{
    [Binding]
    public sealed class StepDefinition1
    {
        
        [Binding]
        public class LogIn_Steps
        {
            public static HomePage homePage;
            public static LoginPage loginPage;
            public static SearchPage searchPage;
            
            
  
            [Given(@"User is at the Home Page")]
            public void GivenUserIsAtTheHomePage()
            {
                homePage = new HomePage();
               
            }
            [BeforeScenario]
            public void BeforeScenarios()
            {
                System.Console.WriteLine("Before scenarios");
            }

            [AfterScenario]
            public void AfterScenarios()
            {
                System.Console.WriteLine("After scenarios.");
            }
            [Given(@"Navigate to LogIn Page")]
            public void GivenNavigateToLogInPage()
            {
               homePage.GotoLoginPage();
            }
            //[When(@"User enter (.*) and (.*)")]
            [When(@"User enter username and password")]
            public void WhenUserEnterAnd(Table table)
            {             
                loginPage = new LoginPage();
                Userinfo oUserinfo = table.CreateInstance<Userinfo>();               
                loginPage.EnterUserName(oUserinfo.username);
                loginPage.EnterPassword(oUserinfo.password);
            }

            [When(@"Click on the LogIn button")]
            public void WhenClickOnTheLogInButton()
            {
                loginPage.ClickLoginButton();                        
            }

            [Then(@"Successful LogIN message should display")]
            public void ThenSuccessfulLogINMessageShouldDisplay()
            {
 
                loginPage.VerifyLoginMessageDisplay();

            }

            [When(@"User enter search text to search input")]
            public void WhenUserEnterSearchTextToSearchInput(Table table)
            {
   
                searchPage = new SearchPage();
                
                searchText oSearch = table.CreateInstance<searchText>();  
                searchPage.SearchProducts(oSearch.searchtext);

            }

            [Then(@"Successful search result items should display")]
            public void ThenSuccessfulSearchResultItemsShouldDisplay()
            {
                searchPage.VerifySearchResult();
            }
            [When(@"User LogOut from the Application")]
            public void WhenUserLogOutFromTheApplication()
            {
                loginPage.ClickLogoutLink();
             }

         

            [Then(@"Successful LogOut message should display")]
            public void ThenSuccessfulLogOutMessageShouldDisplay()
            {

                loginPage.VerifyLogoutMessageDisplay();
                
            }

            [BeforeFeature]
            public static void BeforeFeatures()
            {
                System.Console.WriteLine("Before features");
              //  driver = new FirefoxDriver();
              //  FeatureContext.Current["driver"] = driver;
            }

            [AfterFeature]
            public static void AfterFeatures()
            {
                System.Console.WriteLine("After scenarios.");
               // driver.Dispose();
            }

        }
       
        public class Userinfo
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        public class searchText
        {
            public string searchtext { get; set; }
        }
        
    }
}
