using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Allergo.SeleniumTests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
            }
        }
    }
}
