using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnit
{
    [TestFixture]
    class BrowserNavigations
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupForEveryTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
        }

        [Test, Description("Navigate to URL")]
        public void Browser_BasicNavigations()
        {
            //Navigates the browser to given URL
            driver.Navigate().GoToUrl("http://google.com");
            Assert.True(driver.Url.Contains("https://www.google"), "Validate Navigation to google url");

            driver.Url = "http://facebook.com"; //Almost same as Navigate().GoToUrl() method
            Assert.AreEqual(driver.Url, "https://www.facebook.com/", "Validate Navigation to facebook url");

            driver.Navigate().Back(); //Clicks on back button of browser, navigates back to previously visited url (browser history)
            Assert.True(driver.Url.Contains("https://www.google"), "Validate Navigation to google url");

            driver.Navigate().Forward();//Clicks on forward button of browser, navigates as per browseer history
            Assert.AreEqual(driver.Url, "https://www.facebook.com/", "Validate Navigation to facebook url");

            driver.Navigate().Refresh(); //Reloads the current page
            Assert.AreEqual(driver.Url, "https://www.facebook.com/", "Validate Navigation to facebook url");


            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Back();//Deleting cookies does not effect the browser history
            Assert.True(driver.Url.Contains("https://www.google"), "Validate Navigation to google url");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
