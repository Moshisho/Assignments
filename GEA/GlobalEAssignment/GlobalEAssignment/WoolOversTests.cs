using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using GlobalEAssignment.Helpers;
using GlobalEAssignment.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace GlobalEAssignment
{
    [TestClass]
    public class WoolOversTests
    {
        private static IWebDriver driver;
        private static SeleniumHelper se;
        private static Header header;
        private static WoolOversMainPage mainPage;
        private static OutletPage outletPage;
        private static ItemPage itemPage;

        private static string appURL = ConfigurationManager.AppSettings["app.URL"];
        private static string browserName = ConfigurationManager.AppSettings["browser.name"];

        private static bool didPopUpAppear = false;

        [ClassInitialize]
        public static void Setup(TestContext tc)
        {
            // No need to clear cache as every chromedriver instance is with a new clean user profile.
            driver = SeleniumHelper.CreateWebDriver(browserName);
            se = new SeleniumHelper(driver);

            driver.Navigate().GoToUrl(appURL);
            header = new Header(driver);
            mainPage = PageFactory.InitElements<WoolOversMainPage>(driver);

            didPopUpAppear = mainPage.IsPopUpPresent();
            mainPage.ContinueShopping();
        }

        [TestMethod]
        public void VerifyWelcomePopUp()
        {
            Assert.IsTrue(didPopUpAppear, "Global-E Pop up did not appear on navigating to page.");
        }

        [TestMethod]
        public void IsCorrectFlag()
        {
            // currently il is hard coded but should be recieved from a test context file.
            Assert.AreEqual("il", header.GetFlagLocaleValue());
        }

        [TestMethod]
        public void AddToBagWorking()
        {
            outletPage = mainPage.ClickOutletTab();
            itemPage = outletPage.ClickItem();
            itemPage.AddToBasket();
            bool basketNumCorrect = header.GetBasketCount() == 1;
            Assert.IsTrue(basketNumCorrect && header.GetLocalCurrency().Contains("₪‌"));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
