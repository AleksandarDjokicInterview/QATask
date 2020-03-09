using NUnit.Framework;
using SandBoxAppSelleniumTests.Config;
using SandBoxAppSelleniumTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxAppSelleniumTests.TestCases
{
    class CRUDPersonTestCases : TestConfig
    {
        [SetUp]
        public static void Login()
        {
            LoginPage.Instance.GoToLoginPage();
            LoginPage.Instance.EnterUserNameAndPassword("saledj07@gmail.com", "3ugaCbi3my9AEAB");
            LoginPage.Instance.SubmitLoginData();
        }

        [TearDown]
        public static void LogOut()
        {
            DashBoardPage.Instance.LogOut();
        }

        [Test]
        [Category("Create Person")]
        public static void CreatePersonTests()
        {
            CreatePersonPage.Instance.GoToCreatePersonPage();
            CreatePersonPage.Instance.InsertFullName("Mili Brot");
            CreatePersonPage.Instance.PickFromDropDown("technologies", "IOS");
            CreatePersonPage.Instance.PickFromDropDown("seniority", "Junior");
            CreatePersonPage.Instance.PickFromDropDown("role", "2-nd team");
            CreatePersonPage.Instance.CreateNewPerson();

        }


        [Test]
        [Category("Delete All People")]
        public static void DeleteAllPeopleTests()
        {
            PeoplePage.Instance.GoToPeoplePage();
            var People = PeoplePage.Instance.People;                       
            foreach (var p in People)
            {
                p.Click();
                EditPersonPage.Instance.DeletePerson();
                EditPersonPage.Instance.ConfirmDeletePerson();
            }

        }



    }
}
