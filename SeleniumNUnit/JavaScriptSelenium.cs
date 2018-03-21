using System;
using System.Drawing;
using System.Drawing.Imaging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnit
{

    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    class JavaScriptSelenium
    {
        ChromeDriver driver;
        private IJavaScriptExecutor js;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            js = driver;            // Initialize the JS object.

        }

        [Test, Description("Setting options for Chrome Web Browser")]
        public void Js_GetCurrentPageTitle()
        {
            
            driver.Url = "https://www.wikipedia.org/";
            // Get the current site title.
            
            String sitetitle = (String)js.ExecuteScript("return document.title");
            Assert.AreEqual("Wikipedia", sitetitle, "Verify WebSite Title");

        }

        [Test, Description("Fill a text field without calling the sendKeys()")]
        public void Js_FillText()
        {

            driver.Url = "https://www.wikipedia.org/";
            js.ExecuteScript(
                "document.getElementById('searchInput').value='selenium'"); //Enter 'Seleium' in Search text box

            driver.FindElement(By.XPath("//*[@id=\"search-form\"]/fieldset/button"))
                .Click(); //Click on search button         

            Assert.AreEqual("https://en.wikipedia.org/wiki/Selenium", driver.Url,
                "validate navigation to selenium page");
        }

        [Test, Description("Scroll Down using JavaScriptExecutor.")]
        public void Js_ScrollDown()
        {
            //Launching the Site.		
            driver.Url = "https://www.wikipedia.org/";

            Console.WriteLine(driver.Manage().Window.Size);             // get initial window size

            //WebDriver setSize method used to set window size width = 300 and height = 320.
            driver.Manage().Window.Size = new Size(300, 320);
            Console.WriteLine(driver.Manage().Window.Size);

            var offsetOriginal = js.ExecuteScript("return window.pageYOffset;");


            //Vertical scroll down by 600  pixels		
            js.ExecuteScript("window.scrollBy(0,600)");

            var offsetCurrent = js.ExecuteScript("return window.pageYOffset;");

            Assert.AreNotEqual(offsetCurrent, offsetOriginal, "Offset should change, i.e., scroll down by 600 points");
        }

        [Test, Description("Wait till document and all sub-resources have finished loading")]
        public void Js_WaitForPageLoad()
        {
            //Removing Implicit Waits
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            driver.Url = "https://www.wikipedia.org/";


            //Create explicit wait object
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(x => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return (document.readyState == 'complete')"));

            Assert.AreEqual("https://www.wikipedia.org/", driver.Url,
                "validate navigation to selenium page");
            // The Document.readyState property of a document describes the loading state of the document.
            //The readyState of a document can be one of following:
            //loading - The document is still loading.
            //interactive - The document has finished loading and the document has been parsed but sub-resources such as images, stylesheets and frames are still loading.
            //complete - The document and all sub-resources have finished loading. The state indicates that the load event is about to fire.


            // wait.Until(driver => (bool)((IJavaScriptExecutor)Instance).ExecuteScript("return (document.readyState == 'complete' &&  ((typeof jQuery != 'undefined')? $.active == 0 : true))"));
        }

        [Test, Description("Wait till document finished loading and ajax calls are completed")]
        public void Js_Wait_AjaxCalls()
        {
            //Removing Implicit Waits
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            driver.Url = "https://www.wikipedia.org/";

            //Create explicit wait object
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(drv => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return (document.readyState == 'complete' &&  ((typeof jQuery != 'undefined')? $.active == 0 : true))"));

            //typeof jQuery != 'undefined' means JQuery is loaded and script execution is in progress
            //$.active == 0 -> tests the number of active connections to a server and will evaluate true when the number of connections is zero.
            Assert.AreEqual("https://www.wikipedia.org/", driver.Url,
                "validate navigation to selenium page");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
