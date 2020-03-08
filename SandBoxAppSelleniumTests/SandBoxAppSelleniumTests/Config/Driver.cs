using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;


namespace SandBoxAppSelleniumTests.Config
{
    public static class Driver
    {
        private static WebDriverWait _browserWait;
        private static IWebDriver _browser;
        private static Actions _actions;
        private static ChromeDriverService _driverService;

        public static IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _browser;
            }
            private set => _browser = value;
        }

        public static ChromeDriverService ChromeService
        {
            get
            {
                if (_driverService == null)
                {
                    throw new NullReferenceException("The ChromeDriverService instance was not initialized. You should first call the method Start.");
                }
                return _driverService;
            }
            private set => _driverService = value;
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }
            private set => _browserWait = value;
        }

        public static Actions BrowserActions
        {
            get
            {
                if (_actions == null || _browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser actions instance was not initialized. You should first call the method Start.");
                }
                return _actions;
            }
            private set => _actions = value;
        }

        public static void StartBrowser(int defaultTimeOut = 30)
        {
            var timeOutTime = TimeSpan.FromMinutes(5);
            var co = new ChromeOptions();
            co.AddArgument("no-sandbox");
            co.AddExtensions("C:/ChroPath/extension_5_0_9_0.crx");
            Browser = new ChromeDriver(CreateAndStartChromeService(), co, timeOutTime);            
            Browser.Manage().Window.Maximize();
            Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
            BrowserActions = new Actions(Browser);
        }

        public static ChromeDriverService CreateAndStartChromeService()
        {
            var driverPath = System.Environment.GetEnvironmentVariable("CHROMEDRIVER");
            ChromeService = ChromeDriverService.CreateDefaultService(driverPath);
            ChromeService.Start();
            return _driverService;
        }

        public static void StopBrowser()
        {
            Thread.Sleep(2000);
            Browser.Manage().Cookies.DeleteAllCookies();
            Browser.Quit();
            Browser.Dispose();
            Browser = null;
            ChromeService.Dispose();
            ChromeService = null;
            BrowserWait = null;
            BrowserActions = null;



        }

    }
}
