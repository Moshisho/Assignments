using GlobalEAssignment.Helpers;
using OpenQA.Selenium;

namespace GlobalEAssignment.Pages
{
    abstract class Page
    {
        protected IWebDriver driver;
        protected SeleniumHelper seHelper;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            seHelper = new SeleniumHelper(driver);
            WaitForPageToLoad();
        }

        public abstract void WaitForPageToLoad();
    }
}
