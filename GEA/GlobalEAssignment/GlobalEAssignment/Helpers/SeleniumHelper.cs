using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace GlobalEAssignment.Helpers
{
    class SeleniumHelper
    {
        private IWebDriver driver;
        public IJavaScriptExecutor js;
        public WebDriverWait wait;
        
        public SeleniumHelper(IWebDriver driver)
        {
            this.driver = driver;
            js = this.driver as IJavaScriptExecutor;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)); 
        }

        public static IWebDriver CreateWebDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("incognito");
                    return new ChromeDriver(options);
                case "ie":
                case "firefox":
                case "phnatomjs":
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
