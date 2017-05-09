using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GlobalEAssignment.Pages
{
    class WoolOversMainPage : Page
    {
        private By popUpBy = By.Id("globalePopupWrapper");

        [FindsBy(How = How.Id, Using = "globalePopupWrapper")]
        private IWebElement popUp;

        [FindsBy(How = How.CssSelector, Using = "input[type='button'][value='Continue to shop']")]
        private IWebElement popUpContinueButton;

        // ugly locators simply to save time:
        [FindsBy(How = How.CssSelector, Using = "#menu2 > nav > ul > li:nth-child(7) > a")]
        private IWebElement outletTab;

        public WoolOversMainPage(IWebDriver driver) : base(driver)
        {
        }

        public override void WaitForPageToLoad()
        {
            seHelper.wait.Until(drv => IsPopUpPresent());
        }

        public bool IsPopUpPresent()
        {
            return seHelper.wait.Until(ExpectedConditions.ElementIsVisible(popUpBy)).Displayed;
        }

        public void ContinueShopping()
        {
            popUpContinueButton.Click();
        }

        internal OutletPage ClickOutletTab()
        {
            outletTab.Click();
            return PageFactory.InitElements<OutletPage>(driver);
        }
    }
}
