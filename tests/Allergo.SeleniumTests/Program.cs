using System;
using System.Collections.Generic;
using Allergo.SeleniumTests.Infrastructure;
using Allergo.SeleniumTests.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Allergo.SeleniumTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var testScenarios = new Dictionary<string, ITestScenario>
            {
                {"1", new RegisterTestScenario()}
            };

            while (true)
            {
                foreach (var scenario in testScenarios)
                {
                    Console.WriteLine($"{scenario.Key}: {scenario.Value}");
                }

                Console.WriteLine("B aby przerwać");

                Console.WriteLine("Podaj przypadek testowy do weryfikacji: ");
                var option = Console.ReadLine();

                if (option.Equals("B", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                try
                {
                    testScenarios[option].RunTest();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
