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
    class Guru99LoginPage
    {
        IWebDriver driver;
        By user99GuruName = By.Name("uid");
        By password99Guru = By.Name("password");
        By titleText = By.ClassName("barone");
        By login = By.Name("btnLogin");
        public  Guru99LoginPage(IWebDriver Driver)
        {
            this.driver = Driver;
        }
        //Set user name in textbox
         public void setUserName(String strUserName)
        {
            driver.FindElement(user99GuruName).SendKeys(strUserName);
        }
        //Set password in password textbox
        public void setPassword(String strPassword)
        {
            driver.FindElement(password99Guru).SendKeys(strPassword);
        }
        //Click on login button
        public void clickLogin()
        {
            driver.FindElement(login).Click();
        }
        //Get the title of Login Page
        public String getLoginTitle()
        {
            return driver.FindElement(titleText).Text;
        }

        /**
         * This POM method will be exposed in test case to login in the application
         * @param strUserName
         * @param strPasword
         * @return
         */

        public void loginToGuru99(String strUserName, String strPasword)
        {
            //Fill user name
            this.setUserName(strUserName);
            //Fill password
            this.setPassword(strPasword);
            //Click Login button
            this.clickLogin();
        }
    }
}
