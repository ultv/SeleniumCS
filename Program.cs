using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace testTackSeleniumSC
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://google.com");
            IWebElement body = browser.FindElement(By.TagName("body"));

            body.SendKeys(Keys.Control + "t");

            try
            {
                IWebElement SearchInput = browser.FindElement(By.Id("lst-ib"));
                SearchInput.SendKeys("Simbirsoft" + Keys.Enter);
            }
            catch
            {
                WebDriverWait waitForElement = new WebDriverWait(browser, TimeSpan.FromSeconds(5));                
                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id("lst-ib")));
                /// здесь всё равно генерируется исключение если нет интернета...
                /// предыдущая версия с этим справлялась.

            }

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
