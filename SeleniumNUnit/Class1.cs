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
    public class Class1
    {
       static  IWebDriver driver;

        [TestFixtureSetUp]
        public void fixSetup()
        {
          //to be written
        }

        [SetUp]
        public void TestSetup()
        {
            ChromeOptions options= new ChromeOptions();
           // options.AddArguments("--incognito");  //to open chrome browser in incognito mode
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30); //will wait for  30 seconds before throw the exception
            
        }
        [Test]
        public void Test1()
        {
            //Launch the ToolsQA Website
            driver.Url = "http://www.demoqa.com";

            // Storing Title name in String variable
            String title = driver.Title;

            // Storing Title length in Int variable
            int titleLength = driver.Title.Length;

            // Printing Title name on Console
            Console.WriteLine("Title of the page is : " + title);

            // Printing Title length on console
            Console.WriteLine("Length of the Title is : " + titleLength);

            // Storing URL in String variable
            String PageURL = driver.Url;

            // Storing URL length in Int variable
            int urlLength = PageURL.Length;

            // Printing URL on Console
            Console.WriteLine("URL of the page is : " + PageURL);

            // Printing URL length on console
            Console.WriteLine("Length of the URL is : " + urlLength);

            // Storing Page Source in String variable
            string PageSource = driver.PageSource;

            // Storing Page Source length in Int variable
            int pageSourceLength = driver.PageSource.Length;

            // Printing Page Source on console
            Console.WriteLine("Page Source of the page is : " + PageSource);

            // Printing Page SOurce length on console
            Console.WriteLine("Length of the Page Source is : " + pageSourceLength);

           
        }

        [TearDown]
        public void PostExecution()
        {
            //Closing browser
            driver.Quit();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            //to be written
        }
       
    }
}
