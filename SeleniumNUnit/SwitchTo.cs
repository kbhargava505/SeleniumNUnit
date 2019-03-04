using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Remote;


namespace SeleniumNUnit
{
   [TestFixture]
    class SwitchTo
    {
        IWebDriver driver;
        [SetUp]
        public void TestSetup()
        {
            ChromeOptions options = new ChromeOptions();
            
            // options.AddArguments("--incognito");  //to open chrome browser in incognito mode
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30); //will wait for  30 seconds before throw the exception

        }
        [Test]
        public void AlertHandlings()
        {
            driver.Url = "http://demo.guru99.com/test/delete_customer.php";
            driver.FindElement(By.XPath("//input[@name='cusid']")).SendKeys("3422");
            driver.FindElement(By.XPath("//input[@name='submit']")).Click();
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();
        }
        [Test]
        public void WindowHandle()
        {
            driver.Url = "http://demo.guru99.com/popup.php";
            driver.FindElement(By.XPath("//a[contains(text(),'Click Here')]")).Click();
            string Mainwindow = driver.CurrentWindowHandle;
            IReadOnlyCollection<string> windows = driver.WindowHandles;
            foreach (string a in windows)
            {
                driver.SwitchTo().Window(a);
            }
            driver.FindElement(By.XPath("//input[@name='emailid']")).SendKeys("abc@cdk.com");
            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();
            driver.Close();
            driver.SwitchTo().Window(Mainwindow);
            driver.Close();
        }
        [Test]
        public void iFrameHandle()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            driver.SwitchTo().Frame("a077aa5e");
            driver.FindElement(By.XPath("html/body/a/img")).Click();
            IWebElement ele1 = driver.FindElement(By.XPath("html/body/div/a/img")); //as this is google ad it might change everytime
            driver.SwitchTo().Frame(ele1);  //switching to the frame by element in it
            driver.SwitchTo().DefaultContent();
            //driver.SwitchTo().ParentFrame();   //to come to the parent frame
            driver.Quit();

        }
    }
}
