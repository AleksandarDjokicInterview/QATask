using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SandBoxAppSelleniumTests.Config;
using SandBoxAppSelleniumTests.Pages;

namespace SandBoxAppSelleniumTests.TestCases
{
    [TestFixture]
    public class LoginTestCase : TestConfig
    {
        [Test]
        [Category("LogIn&LogOut")]
        public static void LoginFromLoginPage()
        {
            LoginPage.Instance.GoToLoginPage();
            LoginPage.Instance.EnterUserNameAndPassword("saledj07@gmail.com", "3ugaCbi3my9AEAB");
            LoginPage.Instance.SubmitLoginData();
            DashBoardPage.Instance.LogOut();
        }

    }
}
