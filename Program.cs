using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testTackSeleniumSC
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://google.com");
            IWebElement body = browser.FindElement(By.TagName("body"));

            IWebElement SearchInput = browser.FindElement(By.Id("lst-ib"));
            SearchInput.SendKeys("Simbirsoft" + Keys.Enter);

            IWebElement FirstLink = browser.FindElement(By.ClassName("r"));
            FirstLink.Click();

            if (browser.Url == "https://www.simbirsoft.com/")
            {
                Console.Clear();
                Console.WriteLine($"\n{browser.Url.ToString()} \n\nпервый в списке поиска по фразе \"Simbirsoft\" на сайте google.com");
                browser.Close();
            }

        }
    }
}
