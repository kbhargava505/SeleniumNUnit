using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;

namespace SeleniumNUnit
{
    [TestFixture]
    class KeyboardAndMouseActionsTests
    {
        private IWebDriver Driver;
        private string URL;
        private static bool isPreviousTestFailed = false;

        [TestFixtureSetUp]
        public void TestFixtureSetUP()
        {
            InitializeDriver();
        }

        /// <summary>
        /// Initializes the browser with required configs
        /// </summary>
        private void InitializeDriver()
        {
            Driver = new ChromeDriver();
            URL = "https://www.ultimateqa.com/";
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();
        }


        [SetUp, Description("Executes once before each test case execution")]
        public void SetUp()
        {
            //if previous test execution failed, then kill all existing browser sessions
            //Then initialize and launch a new browser session (fresh start)
            if (isPreviousTestFailed)
            {
                Driver.Quit();
                InitializeDriver();
                isPreviousTestFailed = false;
            }
        }

        [Test, Description("Sample Test to check failure execution flow")]
        public void FailingTestCase()
        {
            Assert.Fail();
        }

        [Test, Description("Identify a web element and click on it")]
        public void Mouse_LeftClick()
        {
            Driver.Url = URL;
            IWebElement Btn_startLearningNow = Driver.FindElement(By.XPath("//a[text()='Start learning now']"));

            //You can also use actions builder class to perform Mouse click operation
            Actions mouseActions = new Actions(Driver);

            Random rand = new Random();

            //randomly use any of the below click methods

            if (rand.Next(1, 2) == 1)
                Btn_startLearningNow.Click();
            else mouseActions.Click(Btn_startLearningNow);

            Assert.AreEqual(Driver.Url, "https://courses.ultimateqa.com/", "Clicked on element and navigated successfully");
        }

        [Test, Description("Double Click a web element in Selenium")]
        public void Mouse_DoubleClick()
        {
            Driver.Url = URL;
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/complicated-page/");
            IWebElement logo = Driver.FindElement(By.Id("logo"));

            //Use actions builder class to perform Mouse Double click operation
            Actions mouseActions = new Actions(Driver);
            mouseActions.DoubleClick(logo).Build().Perform();

            Assert.AreEqual(Driver.Url, URL, "Validate Browser navigated to home page");
        }

        [Test, Description("Perform Mouse Hover action in selenium")]
        public void Mouse_Hover()
        {
            Driver.Url = URL;

            WebDriverWait explicitWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            explicitWait.Until(drv => drv.FindElement(By.XPath("//a[text()='Start learning now']"))); //Ensure element is loaded
            IWebElement Btn_startLearningNow = Driver.FindElement(By.XPath("//a[text()='Start learning now']"));
            //Use actions builder class to perform Mouse Double click operation

            Actions mouseActions = new Actions(Driver);
            mouseActions.MoveToElement(Btn_startLearningNow).Build().Perform(); //When hovered a small arrow appears on button

            System.Threading.Thread.Sleep(5000); //To see the hover event when executing
        }

        [Test, Description("Drag and drop")]
        public void Drag_N_Drop()
        {
            Driver.Url = "http://demoqa.com/draggable/";
            IWebElement sourcElement = Driver.FindElement(By.XPath("//div[@id='draggable']"));
            Actions act = new Actions(Driver);
            act.DragAndDropToOffset(sourcElement,30, 50).Perform();
            Thread.Sleep(2000);
        }


        //add mouse cursor identification tests

        [TearDown, Description("Executes after every test")]
        public void TearDown()
        {
            //Storing the value of execution status, we will use this before next test execution  in Setup method
            isPreviousTestFailed = TestContext.CurrentContext.Result.Status.ToString() == "Failed" ? true : false;
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Driver.Quit();
        }
    }
}