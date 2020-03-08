using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Threading;

namespace SandBoxAppSelleniumTests.Config
{
    [TestFixture]
    public class TestConfig
    {
        [OneTimeSetUp]
        public static void Init()
        {
            Driver.StartBrowser();
        }

        [OneTimeTearDown]
        public static void AfterTest()
        {
            Driver.StopBrowser();
        }
    }
}
