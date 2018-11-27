//This is a POM class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnit
{
    class Guru99HomePage
    {
        IWebDriver driver;
        By homePageUserName = By.XPath("//table//tr[@class='heading3']");
        public Guru99HomePage(IWebDriver Driver)
        {
            this.driver = Driver;
        }
        //Get the User name from Home Page
        public String getHomePageDashboardUserName()
        {
            return driver.FindElement(homePageUserName).Text;
        }
    }
}
