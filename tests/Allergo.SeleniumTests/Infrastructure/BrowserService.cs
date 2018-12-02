using System;
using System.Threading;
using Allergo.SeleniumTests.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Allergo.SeleniumTests.Infrastructure
{
    public class BrowserService : IBrowserService
    {
        private readonly IWebDriver _webDriver;

        public BrowserService()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
        }

        public void Sleep(TimeSpan sleepTime)
            => Thread.Sleep(sleepTime);

        public void GoToUrl(string url)
        {
            _webDriver.Url = url;
            _webDriver.Navigate();
        }

        public void FillInput(By by, string value)
            => _webDriver.FindElement(by).SendKeys(value);

        public void ClickElement(By by)
            => _webDriver.FindElement(by).Click();

        public void Dispose() => _webDriver?.Dispose();
    }
}
