using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        public Size size { get; private set; }

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
        public void TextboxEditing()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/");
            Thread.Sleep(3000);
            IWebElement SearchBar = Driver.FindElement(By.XPath("//input[@class='search']"));
            SearchBar.SendKeys("mouse");
            Thread.Sleep(1000);
            SearchBar.SendKeys(Keys.Return);
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
        [Test]
        public void Radiobuttons()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            IWebElement Radiobutton = Driver.FindElement(By.XPath("//input[@value='single']"));
            System.Drawing.Point value =Radiobutton.Location;
            var selected=Radiobutton.Selected.ToString();
             size = Radiobutton.Size;
            selected= Radiobutton.TagName.ToString();
            selected=Radiobutton.GetCssValue("//input[@value='single']");
        }

        [Test]
        public void SlideSelection()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/");
            IWebElement slideButton = Driver.FindElement(By.XPath("//ul[@id='slide_menu']//a[2]"));
            slideButton.Click();
            
            IWebElement SlidePrice = Driver.FindElement(By.XPath("//p[contains(text(),'$12.00')]"));
            //IList<IWebElement> SlidePrice = Driver.FindElements(By.XPath("//div[@class='price']/p"));         //using different xpath
           // Assert.IsTrue(SlidePrice[0].Text.Contains("$12.00"));
            Assert.IsTrue(SlidePrice.Enabled);

        }

        [Test]
        public void ImageClick()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/");
           string b=(Driver.FindElement(By.XPath("//ul[@class='group']/li[1]/a[3]")).Text);
            Driver.FindElement(By.XPath("//ul[@class='group']/li[1]")).Click(); //clicking on the middle of the li
            Driver.FindElement(By.XPath("//img[@class='product_image']")).Click();
            string a=(Driver.FindElement(By.XPath("//div[@id='pp_full_res']/img")).GetAttribute("style"));
            Driver.FindElement(By.XPath("//a[@class='pp_close']")).Click();
        }

        [Test]
        public void divListItems()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/products-page/product-category/");
            string a = Driver.FindElement(By.XPath("//h1[@class='entry-title']")).Text;
            IList<IWebElement> ProductList =Driver.FindElements(By.XPath("//div[@id='default_products_page_container']/div")); // to get all divs
            IList<IWebElement> Addtocart = Driver.FindElements(By.XPath("//input[@value='Add To Cart']"));
            Addtocart[2].Click();
           Assert.IsNotNull(Driver.FindElement(By.XPath("//div[@class='alert addtocart']")).Size);

        }

        [Test]
        public void PasswordField()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            Driver.FindElement(By.Id("password_2")).SendKeys("Bhar@9908");
            Driver.FindElement(By.Id("confirm_password_password_2")).SendKeys("Bhar@9908");
            Driver.FindElement(By.Id("piereg_passwordStrength")).Click();

        }


        [TestFixtureTearDown]
        public void postExecution()
        {
            Driver.Close();
        }
    }
}
