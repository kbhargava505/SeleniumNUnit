using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace SeleniumNUnit
{
  [TestFixture]
    class WebTable
  {
      private IWebDriver Driver;
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
          Driver  = new ChromeDriver();

        }
        [Test]
        public void UsingMethods()
        {
            Driver.Url = "http://toolsqa.com/automation-practice-table/";
           string a=Driver.FindElement(By.XPath("//table[@class='tsc_table_s13']/thead/tr/th[last()]")).Text;   //use last method
            Console.WriteLine(a);
            a = Driver.FindElement(By.XPath("//td[contains(text(),'60')]")).Text;
            Console.WriteLine(a);
        }
        [Test]
        public void PrecedingAndFollowingElements()
        {
            Driver.Url = "http://toolsqa.com/automation-practice-table/";
            IWebElement b = Driver.FindElement(By.XPath("//td[text()='Dubai']/following-sibling::td/a")); //clicking on details link which is after Dubai text
            b.Click();
            Driver.FindElement(By.XPath("//th[text()='Burj Khalifa']/following-sibling::td[last()]")).Click(); //last item in the row            
            string c = Driver.FindElement(By.XPath("//td[following-sibling::td[text()='Mecca']]")).Text; //it gives the values for which Mecca is following sibling
            Console.WriteLine(c);
            c = Driver.FindElement(By.XPath("//td[preceding-sibling::td[text()='Mecca']]/a")).Text; //gives a for which parent is preceding sibling for Mecca
            Console.WriteLine(c);
            Console.WriteLine(Driver.FindElement(By.XPath("//td[preceding-sibling::td[text()='601m'] and following-sibling::td='2']")).Text);//finding text between 601 and 2
            Console.WriteLine(Driver.FindElement(By.XPath("//td[preceding-sibling::td[text()='UAE']]")).Text);//getting values for which UAE is preceding sibling, it will be in circular form
        }
        [TestFixtureTearDown]
        public void Teardown()
        {
            Driver.Quit();
        }

    }
}
