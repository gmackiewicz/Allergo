using System;
using Allergo.SeleniumTests.Contacts;
using Allergo.SeleniumTests.Contracts;
using Allergo.SeleniumTests.Infrastructure;
using OpenQA.Selenium;

namespace Allergo.SeleniumTests.Tests
{
    public class RegisterAppointmentTestScenario : ITestScenario
    {
        public void RunTest()
        {
            Console.WriteLine(nameof(RegisterAppointmentTestScenario));

            using (IBrowserService browserService = new BrowserService())
            {
                browserService.GoToUrl($"{AllergoConsts.ApplicationUrl}/login");

                browserService.FillInput(By.Id("pp-login"), "patient");
                browserService.FillInput(By.Id("pp-password"), "Haslo123.");

                browserService.ClickElement(By.XPath("//button//span[text()='Zaloguj się']"));
                
                browserService.ClickElement(By.XPath("//app-nav-menu/div/ul/li[2]/a"));

                browserService.FillInput(By.Id("pp-search-doctor"), "Doktor Doktorski");

                browserService.ClickElement(
                    By.XPath("//span[@class='mat-option-text' and contains(text(),'Doktor Doktorski')]"));

                browserService.Sleep(TimeSpan.FromSeconds(3));

                browserService.ClickElement(
                    By.XPath("//mat-accordion//mat-panel-title[contains(text(),'Poniedziałek')]"));

                browserService.ClickElement(
                    By.XPath(
                        "//mat-accordion//div[@class='mat-expansion-panel-body']//button//span[contains(text(),'11:30')]"));

                browserService.ClickElement(By.XPath("//app-set-appointment//button//span[text()='Tak']"));

                browserService.ClickElement(By.XPath("//button//span[contains(text(),'Przejdź do Twoich wizyt')]"));

                browserService.ClickElement(By.XPath(
                    "//mat-expansion-panel//span[@class='mat-content']//mat-panel-title[contains(text(),'11:30')]"));

                browserService.ClickElement(By.XPath("//button//span[contains(text(),'Odwołaj')]"));

                browserService.Sleep(TimeSpan.FromSeconds(2));
            }
        }
    }
}