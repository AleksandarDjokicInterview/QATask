using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SandBoxAppSelleniumTests.Config;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace SandBoxAppSelleniumTests.Config
{
    public abstract class PageObject<TPage> where TPage : new()
    {
    
    private static readonly Lazy<TPage> _lazyPage = new Lazy<TPage>(() => new TPage());
    protected readonly IWebDriver WrappedDriver;
    protected readonly WebDriverWait WrappedWait;
    protected readonly Actions WrappedActions;

    protected PageObject()
    {
        WrappedDriver = Driver.Browser ?? throw new ArgumentNullException("The wrapped IWebDriver instance is not initialized.");
        WrappedWait = Driver.BrowserWait ?? throw new ArgumentNullException("The wrapped WebDriverWait instance is not initialized.");
        WrappedActions = Driver.BrowserActions ?? throw new ArgumentNullException("The wrapped Actions instance is not initialized.");
    }

    public static TPage Instance => _lazyPage.Value;

    public void ClickStaleElementOnPage(By by, int timeInSecond)
    {
        Thread.Sleep(1000);
        var element = FindElement(by, timeInSecond);

        try
        {
            WrappedActions.MoveToElement(element);
            WrappedActions.Perform();
            element.Click();
        }
        catch (Exception ex)
        {
            if (ex is WebDriverException || ex is StaleElementReferenceException)
            {
                var option = WrappedDriver.FindElement(by);
                option.Click();
            }
            else throw ex;
        }
    }

    public void ClickStaleElementOnPage(string xPath, int timeInSecond)
    {
        Thread.Sleep(1000);
        By by = By.XPath(xPath);
        var element = FindElement(by, timeInSecond);

        try
        {
            WrappedActions.MoveToElement(element);
            WrappedActions.Perform();
            element.Click();
        }
        catch (Exception ex)
        {
            if (ex is WebDriverException || ex is StaleElementReferenceException)
            {
                var option = WrappedDriver.FindElement(by);
                option.Click();
            }
            else throw ex;
        }
    }

    public void ClickFirstStaleElementOnPage(string xPath, int timeInSecond)
    {
        Thread.Sleep(1000);
        By by = By.XPath(xPath);

        try
        {
            var element = FindElements(by, timeInSecond).First();
            WrappedActions.MoveToElement(element);
            WrappedActions.Perform();
            element.Click();
        }
        catch (Exception ex)
        {
            if (ex is WebDriverException || ex is StaleElementReferenceException || ex is InvalidOperationException)
            {
                var option = WrappedDriver.FindElements(by).First();
                option.Click();
            }
            else throw ex;
        }
    }

    public void ClickJSBindedElementOnPage(string xPath, int timeInSecond, string newPageUrl)
    {
        Thread.Sleep(1000);
        By by = By.XPath(xPath);
        var element = FindElement(by, timeInSecond);

        while (!WrappedDriver.Url.Equals(newPageUrl))
        {
            element.Click();
            Thread.Sleep(2000);
            UrlValidation(WrappedDriver.Url);
        }
    }

    public IWebElement FindElement(By by, int timeoutInSeconds)
    {
        if (timeoutInSeconds > 0)
        {
            WrappedWait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            return WrappedWait.Until(drv => drv.FindElement(by));
        }
        return WrappedDriver.FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by, int timeoutInSeconds)
    {
        if (timeoutInSeconds > 0)
        {
            WrappedWait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            return WrappedWait.Until(drv => drv.FindElements(by));
        }
        return WrappedDriver.FindElements(by);
    }

    public static void SendKeysExtension(IWebElement input, string text)
    {
        var insertedValue = input.GetAttribute("value");
        if (insertedValue != text)
        {
            // Failed, must send characters one at a time
            input.Clear();

            for (int i = 0; i < text.Count(); i++)
            {
                input.SendKeys(text[i].ToString());
            }
        }
    }

    public void ClickFirstJSBindedElementOnPage(string xPath, int timeInSecond, string newPageUrl)
    {
        Thread.Sleep(1000);
        while (!WrappedDriver.Url.Equals(newPageUrl))
        {
            ClickFirstStaleElementOnPage(xPath, timeInSecond);
            Thread.Sleep(2000);
            UrlValidation(WrappedDriver.Url);
        }
    }

    public void WaitForTransparentBackgroundToDisappear(string transparentBg)
    {
        WrappedWait.Timeout = new TimeSpan(0, 0, 30);
        WrappedWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(transparentBg)));
    }

    public void CatchPopup() => WrappedDriver.SwitchTo().Window(WrappedDriver.WindowHandles.Last());

    public void SwitchToNewWindow() => WrappedDriver.SwitchTo().Window(WrappedDriver.WindowHandles.Last());

    public void UrlValidation(string expectedUrl)
    {
        try
        {
            Assert.AreEqual(expectedUrl, WrappedDriver.Url.ToString());
        }
        catch (AssertionException)
        {
            Thread.Sleep(5000);
            Assert.AreEqual(expectedUrl, WrappedDriver.Url.ToString());
        }
        Assert.Throws<NoSuchElementException>(() => WrappedDriver.FindElement(By.XPath("//h2[contains(text(),'Error Page')]")));
    }

}
}
