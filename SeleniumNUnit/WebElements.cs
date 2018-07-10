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

        [Test]
        public void  DropdownSelection1()
        {

            Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            IWebElement Yeardropdown = Driver.FindElement(By.Id("yy_date_8"));
            SelectElement value = new SelectElement(Yeardropdown);
            IList<IWebElement> years = value.Options;
            value.SelectByIndex(1);
            bool value1 =value.IsMultiple;
            value.SelectByText("2004");
            IWebElement valueselected =value.SelectedOption;
            string valueselected1 =value.SelectedOption.ToString();
            value.DeselectByText("2004");

        }

        [TestFixtureTearDown]
        public void postExecution()
        {
            Driver.Close();
        }
    }
}
