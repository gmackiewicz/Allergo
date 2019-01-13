using Allergo.SeleniumTests.Contacts;
using Allergo.SeleniumTests.Contracts;
using Allergo.SeleniumTests.Infrastructure;
using OpenQA.Selenium;
using System;

namespace Allergo.SeleniumTests.Tests
{
    class CreateScheduleTestScenario : ITestScenario
    {
        public void RunTest()
        {
            Console.WriteLine(nameof(CreateScheduleTestScenario));

            using (IBrowserService browserService = new BrowserService())
            {
                browserService.GoToUrl($"{AllergoConsts.ApplicationUrl}/login");

                browserService.FillInput(By.Id("pp-login"), "doctor");
                browserService.FillInput(By.Id("pp-password"), "Haslo123.");
                browserService.ClickElement(By.XPath("//button//span[text()='Zaloguj się']"));

                browserService.ClickElement(By.XPath("//app-nav-menu/div/ul/li[2]/ul/li/a"));
                
                browserService.ClickElement(By.XPath("//button//span[contains(text(),'Dodaj nowe godziny przyjęć')]"));
                
                browserService.ClickElement(
                    By.Id("pp-add-admission-hour-weekday"));
                browserService.ClickElement(
                    By.XPath("//span[@class='mat-option-text' and contains(text(),'Wtorek')]"));
                browserService.FillInput(By.Id("mat-input-2"), "1000AM");
                browserService.FillInput(By.Id("mat-input-3"), "0200PM");
                browserService.ClickElement(By.XPath("//button//span[text()='Zapisz']"));

                browserService.Sleep(TimeSpan.FromSeconds(1));

                browserService.ClickElement(
                    By.XPath("//mat-accordion//mat-panel-title[contains(text(),'Wtorek')]"));

                browserService.ClickElement(
                    By.XPath(
                        "//mat-accordion//div[@class='mat-expansion-panel-body']//button//span[contains(text(),'10:00 - 14:00')]"));

                browserService.ClickElement(By.XPath("//app-remove-admission-hour//button//span[text()='Tak']"));

                Console.ReadKey();
            }
        }
    }
}
