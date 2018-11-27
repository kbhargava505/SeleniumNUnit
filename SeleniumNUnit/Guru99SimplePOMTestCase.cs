//This is POM test case
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SeleniumNUnit
{
    [TestFixture]
    class Guru99SimplePOMTestCase
    {
        IWebDriver driver;
        Guru99LoginPage objLogin;
        Guru99HomePage objHomePage;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://demo.guru99.com/V4/");
        }
        /**
         * This test case will login in http://demo.guru99.com/V4/
         * Verify login page title as guru99 bank
         * Login to application
         * Verify the home page using Dashboard message
         */
        [Test]
        public void test_Home_Page_Appear_Correct()
        {
            //Create Login Page object
            objLogin = new Guru99LoginPage(driver);
            //Verify login page title
            string loginPageTitle = objLogin.getLoginTitle();
            Assert.IsTrue(loginPageTitle.ToLower().Contains("guru99 bank"));
            //login to application
            objLogin.loginToGuru99("mgr123", "mgr!23");
            // go the next page
            objHomePage = new Guru99HomePage(driver);
            //Verify home page
            Assert.IsTrue(objHomePage.getHomePageDashboardUserName().ToLower().Contains("manger id : mgr123"));
        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
