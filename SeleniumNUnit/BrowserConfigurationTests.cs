using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumNUnit
{
    [TestFixture]
    public class BrowserConfigurationTests
    {

        ChromeDriver driver;
        ChromeOptions options;


        [Test, Description("Setting options for Chrome Web Browser")]
        public void Chrome_BrowserOptions()
        {
            //From the command line you can run 'chromedriver -help' command to see list of arguments for your version

            //http://www.assertselenium.com/java/list-of-chrome-driver-command-line-arguments/
            options  = new ChromeOptions();
            options.AddArguments("start-maximized"); //Start Browser in Maximized mode
            options.AddArguments("--disable-extensions"); //disable all extensions
            options.AddExcludedArgument("ignore-certificate-errors"); //Ignore certificate error warnings
            options.AddArguments("--test-type"); //Disable test mode warning message
            driver = new ChromeDriver(options);

            driver.Url = "https://google.com";
            Assert.IsTrue(driver.Url.ToLower().Contains("google"), "Head Less browser Navigated successfully");
        }


        [Test, Description("This option will tell Google Chrome to execute in headless mode.")]
        public void Chrome_HeadLessBrowser()
        {
            options = new ChromeOptions();
            options.AddArguments("--headless");
            driver = new ChromeDriver(options);
            driver.Url = "https://google.com";
            Assert.IsTrue(driver.Url.ToLower().Contains("google"), "Head Less browser Navigated successfully");
        }

        [Test, Description("This option will tell Google Chrome to open in incongito.")]
        public void Chrome_IncongitoBrowser()
        {
            options = new ChromeOptions();
            options.AddArguments("--incognito");
            driver = new ChromeDriver(options);
            driver.Url = "https://google.com";
            Assert.IsTrue(driver.Url.ToLower().Contains("google"), "Head Less browser Navigated successfully");
        }

        [Test, Description("This option will allow browser pop-ups.")]
        public void Chrome_DisablePopUpBlocking()
        {
            options = new ChromeOptions();
            options.AddArgument("--disable-popup-blocking");
            driver = new ChromeDriver(options) {Url = "https://google.com"};
            Assert.IsTrue(driver.Url.ToLower().Contains("google"), "Head Less browser Navigated successfully");
        }
      
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
