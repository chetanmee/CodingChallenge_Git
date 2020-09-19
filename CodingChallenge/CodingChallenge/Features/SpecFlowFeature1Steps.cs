using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;


namespace ClassLibrary1
{
    [Binding]
    public class CargaintFeatureSteps : IDisposable
    {
        private String searchKeyword;
        List<string> MyList = new List<string>();

        private ChromeDriver chromeDriver;

        public CargaintFeatureSteps() => chromeDriver = new ChromeDriver();

        [Given(@"I have navigated to cargiant website login page")]
        public void GivenIhavenavigatedtocargiantwebsiteloginpage()
        {
            chromeDriver.Navigate().GoToUrl("https://www.cargiant.co.uk/login");
            String Msg = "Sign In To Your My Garage Account - Cargiant";
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains(Msg.ToLower()));
            
        }

        [Given(@"I have entered username '(.*)' and password '(.*)' as valid userdetails to login")]
        public void GivenIhaveenteredusernameandpasswordasvaliduserdetailstologin(string username, string password)
        {
            //Locate the Web Elements
            var loginbutton = chromeDriver.FindElement(By.XPath("//a[@href='/login']"));
            var usernamebox = chromeDriver.FindElement(By.Name("PartialLogin.Username"));
            var passwordbox = chromeDriver.FindElement(By.Name("PartialLogin.Password"));
            var signin = chromeDriver.FindElement(By.XPath("//form[@class='login-form']"));
                     

            //Perform Required action with the element

            usernamebox.SendKeys(username);
            passwordbox.SendKeys(password);
            signin.Submit();

            
        }

        [When(@"search the Manufacturer Audi")]

        public void WhensearchtheManufacturerAudi()
        {
            //Locate the Web Elements
            var Homebutton = chromeDriver.FindElement(By.XPath("//a[contains(.//text(), 'Home')]"));
            //var findcar =
            clickpopup();
            Homebutton.Click();
            Thread.Sleep(1000);
            var Make = chromeDriver.FindElement(By.XPath("//a[contains(.//text(), 'Make')]"));
            clickpopup();
            Make.Click();
            var Audi = chromeDriver.FindElement(By.XPath("//a[@data-value='audi']"));
            clickpopup();
            Audi.Click();
            var searchbutton = chromeDriver.FindElement(By.XPath("//div//button[@type='submit']"));
            clickpopup();
            searchbutton.Click();
            var carlist = chromeDriver.FindElements(By.XPath("//div[@class='vehicle-tile__actions']"));



            foreach (var a in carlist)
            {
                if (a.FindElement(By.TagName("a")).GetAttribute("data-url") == null)
                {

                }
                else
                {
                    MyList.Add(@"https://www.cargiant.co.uk/" + a.FindElement(By.TagName("a")).GetAttribute("data-url"));

                }
            }

        }
        [When(@"add to the Watchlist")]
        public void addtotheWatchlist()
        {


            for (int i = 0; i < 3; i++)
            {
                clickpopup();
                chromeDriver.Navigate().GoToUrl(MyList[i]);

            }
            chromeDriver.Navigate().GoToUrl("https://www.cargiant.co.uk/my-garage");

        }


        
        [When(@"Delete one of the watchlist")]

        public void WhenDeleteoneofthewatchlist()
        {
            chromeDriver.Navigate().GoToUrl(chromeDriver.FindElement(By.XPath("//a[@class='show-for-medium-down remove-watchlist']")).GetAttribute("href"));
            // chromeDriver.Navigate().GoToUrl("https://www.cargiant.co.uk/my-garage");


            // Removeitem.Click();
        }


        [Given(@"I have entered (.*) as search keyword")]
        public void GivenIHaveEnteredIndiaAsSearchKeyword(String searchString)
        {
            this.searchKeyword = searchString.ToLower();
            var searchInputBox = chromeDriver.FindElementById("search");
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search")));
            searchInputBox.SendKeys(searchKeyword);
        }

        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = chromeDriver.FindElementByCssSelector("button#search-icon-legacy");
            searchButton.Click();
        }

           public void clickpopup()
        {
            try
            {


                var popup = chromeDriver.FindElement(By.XPath("//div//a[@class='CallToActionPopupBlock__CallToActionLink-sc-1u8k8qw-0 WbTln']"));


                popup.Click();


            }
            catch (Exception)
            {

            }
        }

        [Then(@"Sort the List")]

        public void ThenSorttheList()
        {
            //var Mainlist = chromeDriver.FindElement(By.XPath("//div[@class='list']")).FindElement(By.TagName("a"));
            //var list = chromeDriver.FindElements(By.XPath("//a[@data-value='1']"));


            //list[0].Click();
            //var optionlist= chromeDriver.FindElement(By.XPath("//div[@class='list-show']"));
            //var innerlist = optionlist.FindElement(By.XPath("//a[@data-value='1']"));
            //innerlist.Click();
            //Mainlist.Click();
        }


        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}