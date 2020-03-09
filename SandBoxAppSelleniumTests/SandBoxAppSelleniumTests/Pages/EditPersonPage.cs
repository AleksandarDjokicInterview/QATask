using OpenQA.Selenium;
using SandBoxAppSelleniumTests.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxAppSelleniumTests.Pages
{
    public class EditPersonPage : PageObject<EditPersonPage>
    {       
        #region XPathValues
        public string fullNameXPath = "//input[contains(@placeholder,'* Full Name')]";                                       
        public string selectTechnologiesXPath = "//input[@name='technologies']//parent::div[1]";
        public string selectSeniorityXPath = "//input[@name='seniority']//parent::div[1]";
        public string selectTeamXPath = "//input[@name='role']//parent::div[1]";
        public string submitButtonXPath = "//button[contains(@class,'btn btn-primary mt-4 float-right')]";
        public string dropdownXPathFirstPart = "//input[@name='";
        public string dropdownXPathSecondPart = "']//parent::div[1]";
        public string newPersonTextXPath = "//b[contains(text(),'New Person')]";
        public string deletePersonXPath = " //i[contains(@class,'far fa-trash-alt')]";
        public string alertDeleteXPath = "//button[contains(@class,'btn btn-lg btn-danger')]";
        #endregion

        #region WebElements
        public IWebElement FullNameTextBox { get { return FindElement(By.XPath(fullNameXPath), 15); } }
        public IWebElement SelectTechnologiesDropDown { get { return FindElement(By.XPath(selectTechnologiesXPath), 15); } }
        public IWebElement SelectSeniorityDropDown { get { return FindElement(By.XPath(selectSeniorityXPath), 15); } }
        public IWebElement SelectTeamDropDown { get { return FindElement(By.XPath(selectTeamXPath), 15); } }
        public IWebElement SubmitButton { get { return FindElement(By.XPath(submitButtonXPath), 15); } }
        public IWebElement NewPersonText { get { return FindElement(By.XPath(newPersonTextXPath), 15); } }
        public IWebElement DeletePersonButton { get { return FindElement(By.XPath(deletePersonXPath), 15); } }
        public IWebElement AlertDeleteButton { get { return FindElement(By.XPath(alertDeleteXPath), 15); } }

        #endregion

        #region Methods
        public void GoToPersonPage(int personId)
        {
            WrappedDriver.Navigate().GoToUrl(Constants.PEOPLE + "/" + personId);
        }

        public void PickFromDropDown(string dropdown, string text)
        {
            string dropdownXpath = dropdownXPathFirstPart + dropdown + dropdownXPathSecondPart;
            WrappedDriver.FindElement(By.XPath(dropdownXpath)).Click();
            string xpath = "//span[contains(text(),'" + text + "')]";
            WrappedDriver.FindElement(By.XPath(xpath)).Click();
            NewPersonText.Click();
            //string optionsXPath = "//span[@role='option']";
            //var options = WrappedDriver.FindElements(By.XPath(optionsXPath));
            //options.FirstOrDefault(e => e.Text.Contains(text)).Click();
        }

        public void InsertFullName(string fullname)
        {
            FullNameTextBox.SendKeys(fullname);
        }

        public void EditNewPerson()
        {
            SubmitButton.Click();
        }

        public void DeletePerson()
        {
            DeletePersonButton.Click();
        }

        public void ConfirmDeletePerson()
        {
            AlertDeleteButton.Click();
        }

        #endregion
    }
}
