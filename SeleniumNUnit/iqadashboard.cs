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
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void dataFetch()
        {


            driver.Url = "http://gbhpiqaweb01.dsi.ad.adp.com/ivc/signin.html#";
            driver.FindElement(By.XPath(@"//input[@id='username']")).SendKeys("kanamarb");
            driver.FindElement(By.XPath(@"//input[@id='password']")).SendKeys("jul@2018");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(@"//a[@id='sign_in']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(@"//input[@id='date_results']")).Click();
            driver.FindElement(By.XPath("//td[@class='old day'][contains(text(),'27')]")).Click();
            getcelldata("//table[@class=' table-condensed']", "25",
                false); //selecting date using xpath from date picker
            driver.Quit();
        }

        public void getcelldata(string xpath, string value, bool multiple = false)
        {
            IWebElement Element;
            int Count = 0;
            IList<IWebElement> Data = driver.FindElements(By.XPath(xpath + "//" + "thead"));
            IList<IWebElement> values = Data[0].FindElements(By.XPath(xpath + "//" + "tbody/tr"));
            foreach (var elemTr in values)
            {
                IList<IWebElement> tdCols = elemTr.FindElements(By.TagName("td"));
                if (tdCols.Count > 0)
                {
                    foreach (var eletd in tdCols)
                    {
                        if (eletd.Text == value)
                        {
                            eletd.Click();
                            if (multiple == false)
                            {
                                goto endloop;

                            }
                            else
                            {
                                Count++;
                                goto nextloop;

                            }
                        }
                    }
                }

                nextloop:
                if (Count > 0)
                {

                    Console.WriteLine("Checking for one more value");
                    {
                        Data = driver.FindElements(By.XPath(xpath + "//" + "thead"));
                        values = Data[0].FindElements(By.XPath(xpath + "//" + "tbody/tr"));
                    }
                }
            }

            endloop:
            Console.WriteLine("Value has been clicked");
        }

        [Test]
        public void DatePickerwith2Months()
        {
            driver.Url = "https://www.turkishairlines.com/tr-tr/";
            
            driver.FindElement(By.XPath(@".//*[@id='calendarPlaceholder']/span[1]")).Click();
            driver.FindElement(By.XPath(@"(//div/table[@class='ui-datepicker-calendar'])[2]/tbody/tr/td/a[contains(text(),23)]")).Click();
        }
    }
}


