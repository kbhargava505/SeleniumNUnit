using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework;

namespace SeleniumNUnit
{

    /*
     *
     *Most of the time we think to Capture Screenshot in WebDriver when some kind of error or exception surfaces while practicing testing,
     * to resolve the same WebDriver has provided us one interface TakesScreenshot for capturing the screenshot of web application and
     * this interface provides one method names as getScreenshotAs() to capture screenshot in instance of driver.
     *
     * This getScreenshotAs() method takes argument of type OutputType.File or OutputType.BASE64 or Output.BYTES.
     * So that it could return captured screenshot in File type, or Base 64 string type or in raw bytes.
     *
     */
    [TestFixture]
    public class ScreenCapture
    {
        IWebDriver driver;

        /// <summary>
        /// This test is not supposed to fail and takes two screenshots
        /// </summary>
        [Test, Description("Test to capture screen as a picture at runtime and save it locally")]
        public void SimpleScreenshot1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.co.in");
            driver.TakeScreenshot().SaveAsFile(@"C:\\Automation\capture1.jpeg", ScreenshotImageFormat.Jpeg);
            driver.Manage().Window.Size = new Size(300, 320); //will resize the chrome window with scroll bars
            driver.TakeScreenshot().SaveAsFile(@"C:\\Automation\capture2.jpeg", ScreenshotImageFormat.Jpeg);
            driver.Close();
        }


        /// <summary>
        /// This Test will always Fail and take screenshot at end
        /// </summary>
        [Test, Description("Take screen shot ONLY for failed tests")]
        public void TakeScreenShot_ForFailedScriptsOnly()
        {
            //Use method'TearDown', which calls the code to take screen shot on failure.
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com");
            Assert.Fail();
        }

        [TearDown]
        public void TearDown()
        {
            //check if the test execution failed
            if (TestContext.CurrentContext.Result.Status.ToString() == "Failed")
            {
                //if the test executio failed, fetch the current test name and its class
                string fullTestName = TestContext.CurrentContext.Test.FullName;
                //Take screenshot of the browser, this is used as reference while debugging
                driver.TakeScreenShot(fullTestName);
            }
        }

        [TestFixtureTearDown]
        public void TextFixtureTearDown()
        {
            driver.Quit();
        }
    }


    public static class ExtensionMethodClass
    {
        /// <summary>
        /// Take Screenshot of the driver instance
        /// </summary>
        /// <param name="drv">driver instance on which the method is called</param>
        /// <param name="className">Class name of the current test</param>
        /// <param name="testName">Test name of the current test</param>
        public static void TakeScreenShot(this IWebDriver drv, string fullTestName)
        {
            string root = @"C:\Automation\";  //root directory to save screenshot
            // If directory does not exist,create it
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            //Take screenshot and save it
            drv.TakeScreenshot().SaveAsFile(root + fullTestName + ".jpeg",
                ScreenshotImageFormat.Jpeg);
        }
    }

}