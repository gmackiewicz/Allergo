using System;
using System.Threading;
using Allergo.SeleniumTests.Contacts;
using Allergo.SeleniumTests.Contracts;
using Allergo.SeleniumTests.Infrastructure;
using OpenQA.Selenium;

namespace Allergo.SeleniumTests.Tests
{
    public class RegisterTestScenario : ITestScenario
    {
        public void RunTest()
        {
            Console.WriteLine("RegisterTestScenario");

            using (IBrowserService browserService = new BrowserService())
            {
                browserService.GoToUrl($"{AllergoConsts.ApplicationUrl}/register");

                browserService.FillInput(By.Id("pp-portal_login"), "portal_login");
                browserService.FillInput(By.Id("pp-portal_password"), "portal_password");

                browserService.ClickElement(By.XPath("//button//span[text()='Dalej']/.."));

                browserService.FillInput(By.Id("pp-email"), "test@allergo.pl");
                browserService.FillInput(By.Id("pp-login"), "allergo_login");
                browserService.FillInput(By.Id("pp-password"), "Allergo_pass123*");
                browserService.FillInput(By.Id("pp-confirm-password"), "Allergo_pass123*");

                browserService.ClickElement(By.XPath("//button//span[text()='Zarejestruj się']/.."));

                browserService.Sleep(TimeSpan.FromMinutes(1));
            }
        }
    }
}
