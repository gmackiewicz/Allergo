using System;
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

                browserService.FillInput(By.Id("mat-input-0"), "portal_login");
                browserService.FillInput(By.Id("mat-input-1"), "portal_password");

                browserService.ClickElement(By.XPath("//button//span[text()='Dalej']/.."));

                browserService.FillInput(By.Id("mat-input-2"), "test@allergo.pl");
                browserService.FillInput(By.Id("mat-input-3"), "allergo_login");
                browserService.FillInput(By.Id("mat-input-4"), "Allergo_pass123*");
                browserService.FillInput(By.Id("mat-input-5"), "Allergo_pass123*");

                browserService.ClickElement(By.XPath("//button//span[text()='Zarejestruj się']/.."));

                browserService.Sleep(TimeSpan.FromMinutes(1));
            }
        }
    }
}
