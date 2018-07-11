using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SeleniumNUnit
{
    [TestFixture]
    class iqadashboard
    {
        [Test]
        public void dataFetch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://gbhpiqaweb01.dsi.ad.adp.com/ivc/signin.html#";
            driver.FindElement(By.XPath(@"//input[@id='username']")).SendKeys("kanamab");
            driver.FindElement(By.XPath(@"//input[@id='password']")).SendKeys("mar@2018");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(@"//a[@id='sign_in']")).Click();
            Thread.Sleep(3000);

            driver.Quit();
        }
        
      
    }
}
