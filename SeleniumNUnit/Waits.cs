using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace SeleniumNUnit
{
    [TestFixture]
    class Waits
    {
        private IWebDriver driver;
        private WebDriverWait check;

        [SetUp]
        public void SetupForEveryTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            check = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test, Description("using webDriveWait")]
        public void TypesofWaits()
        {
            //Navigates the browser to given URL
            driver.Navigate().GoToUrl("http://google.com");
            check.Until(ExpectedConditions.ElementExists(By.Name("btnK"))); 
            Assert.True(driver.Url.Contains("https://www.google"), "Validate Navigation to google url");

            driver.Url = "http://facebook.com"; //Almost same as Navigate().GoToUrl() method
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.MaxValue;//Implicit wait //wait till the time span max value(2.5hrs)
            Assert.AreEqual(driver.Url, "https://www.facebook.com/", "Validate Navigation to facebook url");

            driver.Navigate().Back(); //Clicks on back button of browser, navigates back to previously visited url (browser history)
            Thread.Sleep(1000);     //explicit wait
            Assert.True(driver.Url.Contains("https://www.google"), "Validate Navigation to google url");

            driver.Navigate().Forward();//Clicks on forward button of browser, navigates as per browseer history
            Assert.AreEqual(driver.Url, "https://www.facebook.com/", "Validate Navigation to facebook url");

            driver.Navigate().Refresh(); //Reloads the current page
            IWebElement CreateAccount = check.Until(ExpectedConditions.ElementToBeClickable(By.Name("websubmit")));
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
