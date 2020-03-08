using OpenQA.Selenium;
using SandBoxAppSelleniumTests.Config;
using System;

namespace SandBoxAppSelleniumTests
{
    public class LoginPage : PageObject<LoginPage>
    {
        #region XPathValues
        public string submitButtonXPath = "//button[text()='Submit']";
        public string usernameInput = "//input[@placeholder='Email Address']";
        public string passwordInput = "//input[@placeholder='Password']";        
        #endregion

        #region WebElements
        public IWebElement SubmitButtonXPath { get { return FindElement(By.XPath(submitButtonXPath), 15); } }
        public IWebElement UsernameInput { get { return FindElement(By.XPath(usernameInput), 15); } }
        public IWebElement PasswordInput { get { return FindElement(By.XPath(passwordInput), 15); } }        
        #endregion

        #region Methods
        public void GoToLoginPage()
        {
            WrappedDriver.Navigate().GoToUrl(Constants.LOGINPAGE);    
        }

        public void EnterUserNameAndPassword(string username, string password)
        {
            SendKeysExtension(UsernameInput, username);            
            SendKeysExtension(PasswordInput, password);            
        }

        public void SubmitLoginData()
        {
            SubmitButtonXPath.Click();
        }
        #endregion
    }
}
