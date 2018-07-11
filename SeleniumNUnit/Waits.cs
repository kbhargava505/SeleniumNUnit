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

            //**************** Explicit or Fluent waits

            //Navigates the browser to given URL
            driver.Navigate().GoToUrl("http://google.com");
            check.Until(ExpectedConditions.ElementExists(By.Name("btnK"))); 
            Assert.True(driver.Url.Contains("https://www.google"), "Validate Navigation to google url");

            driver.Navigate().GoToUrl("https://www.facebook.com/");
            IWebElement CreateAccount = check.Until(ExpectedConditions.ElementToBeClickable(By.Name("websubmit")));
            Assert.AreEqual(driver.Url, "https://www.facebook.com/", "Validate Navigation to facebook url");

            //************** Default wait is Webdriver independent
            //Go to http://toolsqa.wpengine.com/automation-practice-switch-windows/
            //There is a clock on the page that counts down till 0 from 60 second.
            //You have to wait for the clock to show text “Buzz Buzz”
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            IWebElement element1 = driver.FindElement(By.Id("clock"));
            DefaultWait<IWebElement> wait1 = new DefaultWait<IWebElement>(element1);
            wait1.Timeout=TimeSpan.FromMinutes(2);
            wait1.PollingInterval=TimeSpan.FromMilliseconds(250);
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String styleAttrib = element1.Text;
                if (styleAttrib.Contains("Buzz"))
                {
                    return true;
                }
                Console.WriteLine("Current time is " + styleAttrib);
                return false;
            });
            wait1.Until(waiter);


            //Go to http://toolsqa.wpengine.com/automation-practice-switch-windows/
            //There is a button which color will change after some time
            //You have to wait for the newc color
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Console.WriteLine("Waiting for color to change");
                IWebElement element = Web.FindElement(By.Id("target"));
                if (element.GetAttribute("style").Contains("red"))
                {
                    return true;
                }
                return false;
            });
            wait.Until(waitForElement);

            //Go to http://toolsqa.wpengine.com/automation-practice-switch-windows/
            //There is a button which color will change after some time
            //You have to wait for the newc color 
            //this time we'll return a element type only
           // driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
           // WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
           // Func<IWebDriver, IWebElement> waitForElement2 = new Func<IWebDriver, IWebElement>((IWebDriver Web) =>
           // {
           //     Console.WriteLine("Waiting for color to change");
           //     IWebElement element = Web.FindElement(By.Id("target"));
           //     if (element.GetAttribute("style").Contains("red"))
           //     {
           //         return element;
           //     }
           //     return null;
           // });
           //// IWebElement targetElement = wait2.Until(waitForElement);            //*****************conversion error is coming we need to look into this
           // Console.WriteLine("Inner HTML of element is " + targetElement.GetAttribute("innerHTML"));


            //**************** Implicit waits
            driver.Url = "http://facebook.com"; //Almost same as Navigate().GoToUrl() method
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.MaxValue;//Implicit wait //wait till the time span max value(2.5hrs)
            Assert.AreEqual(driver.Url, "https://www.facebook.com/", "Validate Navigation to facebook url");

            driver.Navigate().GoToUrl("http://google.com"); //Clicks on back button of browser, navigates back to previously visited url (browser history)
            Thread.Sleep(1000);     //explicit wait
            Assert.True(driver.Url.Contains("http://google.com"), "Validate Navigation to google url");
            
            driver.Url = "http://facebook.com"; //Almost same as Navigate().GoToUrl() method
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
