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
        public void TableHeader()
        {
            Driver.Url = "http://toolsqa.com/automation-practice-table/";
           string a=Driver.FindElement(By.XPath("//table[@class='tsc_table_s13']/thead/tr/th[last()]")).Text;   //use last method
            Console.WriteLine(a);
        }
    }
}
