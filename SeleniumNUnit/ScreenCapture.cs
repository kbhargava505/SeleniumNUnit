using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
namespace SeleniumNUnit
{
   [TestFixture]
    public class ScreenCapture
    {
        [Test]
        public void SimpleScreenshot1()
        {
            IWebDriver driver = new ChromeDriver();
            var firingDriver= new EventFiringWebDriver(driver);
            driver.Navigate().GoToUrl("https://www.google.co.in");
            driver.TakeScreenshot().SaveAsFile(@"C:\\Automation\capture1.jpeg", ScreenshotImageFormat.Jpeg);
            driver.Manage().Window.Size = new Size(300, 320); //will resize the chrome window with scroll bars
            driver.TakeScreenshot().SaveAsFile(@"C:\\Automation\capture2.jpeg", ScreenshotImageFormat.Jpeg);
            driver.Close();
        }
        
    }
}