using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GlobalEAssignment.Pages
{
    class OutletPage : Page
    {
        private By firstImgItemBy = By.CssSelector("#listing-container > div.col-xs-12.col-sm-9.col-xlg-10 > div.row > div > div > div > div:nth-child(1) > div.associated-product__image > div.owl-carousel-ajax.owl-carousel > div > a > img");

        [FindsBy(How = How.CssSelector, Using = "#listing-container > div.col-xs-12.col-sm-9.col-xlg-10 > div.row > div > div > div > div:nth-child(1) > div.associated-product__image > div.owl-carousel-ajax.owl-carousel > div > a > img")]
        private IWebElement firstImgItem;

        public OutletPage(IWebDriver driver) : base(driver)
        {
        }

        public override void WaitForPageToLoad()
        {
            seHelper.wait.Until(ExpectedConditions.ElementIsVisible(firstImgItemBy));
        }

        internal ItemPage ClickItem()
        {
            firstImgItem.Click();
            return PageFactory.InitElements<ItemPage>(driver);
        }
    }
}
