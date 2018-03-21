using System;
using System.Collections.Generic;
using System.Linq;
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
    class WebElements
    {
        private IWebDriver Driver;

        [TestFixtureSetUp]
        public void preExec()
        {
            Driver = new ChromeDriver();
        }
        [Test]
        public void RadioButtonSelection()
        {
            
            Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            IWebElement MarriedRadioBtn = Driver.FindElement(By.XPath("//input[@value='married']"));
            if(!MarriedRadioBtn.Selected)
                MarriedRadioBtn.Click();

            Assert.IsTrue(MarriedRadioBtn.Selected);

        }

        [Test]
        public void DropDownSelection()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            IWebElement Country = Driver.FindElement(By.XPath("//select[@id='dropdown_7']"));

            SelectElement CountrySelection = new SelectElement(Country);
            CountrySelection.SelectByText("Fiji");
            Thread.Sleep(3000);

        }

        [TestFixtureTearDown]
        public void postExecution()
        {
            Driver.Close();
        }
    }
}
