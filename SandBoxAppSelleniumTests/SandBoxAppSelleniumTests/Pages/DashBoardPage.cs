using OpenQA.Selenium;
using SandBoxAppSelleniumTests.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandBoxAppSelleniumTests.Pages
{
    class DashBoardPage : PageObject<DashBoardPage>
    {
        #region XPathValues
        public string logoutXPath = "//a[contains(text(),'Logout')]";
      
        #endregion

        #region WebElements
        public IWebElement LogoutLink { get { return FindElement(By.XPath(logoutXPath), 15); } }
      
        #endregion

        #region Methods
        public void GoToDashBoardPage()
        {
            WrappedDriver.Navigate().GoToUrl(Constants.DASHBOARD);
        }
        
        public void LogOut()
        {
            LogoutLink.Click();
        }
        #endregion
    }
}
