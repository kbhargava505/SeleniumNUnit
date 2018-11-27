using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
namespace SeleniumNUnit
{
    [TestFixture]
    class PageFactoryTestCase
    {
        [Test]
        public void PageFactoryTest1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.store.demoqa.com";

            var homePage = new HomePageObjects();
            PageFactory.InitElements(driver, homePage); //this is to create the elements
            homePage.MyAccount.Click();

            var loginPage = new LoginPageObjects();
            PageFactory.InitElements(driver, loginPage);
            loginPage.UserName.SendKeys("TestUser_1");
            loginPage.Password.SendKeys("Test@123");
            loginPage.Submit.Submit();
        }    
 
    }
}
