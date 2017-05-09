using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GlobalEAssignment.Pages
{
    class ItemPage : Page
    {
        [FindsBy(How = How.CssSelector, Using = "div.product-option[data-size='Extra Small']")]
        private IWebElement xsSize;

        [FindsBy(How = How.CssSelector, Using = "button[value='Add to bag']")]
        private IWebElement addToBagButton;

        public ItemPage(IWebDriver driver) : base(driver)
        {
        }

        public override void WaitForPageToLoad()
        {
            seHelper.wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("pageContents")));
        }

        public void AddToBasket()
        {
            xsSize.Click();
            seHelper.wait.Until(ExpectedConditions
                .ElementToBeClickable(By.CssSelector("button[value='Add to bag']")));
            addToBagButton.Click();
        }
    }
}
