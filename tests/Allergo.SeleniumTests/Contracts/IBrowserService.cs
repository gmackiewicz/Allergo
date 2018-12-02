using System;
using OpenQA.Selenium;

namespace Allergo.SeleniumTests.Contracts
{
    public interface IBrowserService : IDisposable
    {
        void Sleep(TimeSpan sleepTime);
        void GoToUrl(string url);
        void FillInput(By by, string value);
        void ClickElement(By by);
    }
}
