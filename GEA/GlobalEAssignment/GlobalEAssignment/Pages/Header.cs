using OpenQA.Selenium;
using System.IO;
using System.Text.RegularExpressions;

namespace GlobalEAssignment.Pages
{
    class Header
    {
        private IWebDriver driver;

        private readonly By bagBy = By.CssSelector("span.js-cart-total");
        private readonly By costBy = By.CssSelector("span.js-cart-cost");
        private readonly By imgFlagBy = By.CssSelector("li.nav-dropdown-container > span > img[src*='flags']");

        public Header(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal int GetBasketCount()
        {
            return short.Parse(driver.FindElement(bagBy).Text);
        }

        internal string GetLocalCurrency()
        {
            return driver.FindElement(costBy).Text;
        }

        internal string GetFlagLocaleValue()
        {
            IWebElement imgFlag = driver.FindElement(imgFlagBy);

            Regex regex = new Regex(@"[^/\\&\?]+\.\w{3,4}(?=([\?&].*$|$))");

            return Path.GetFileNameWithoutExtension(regex.Match(imgFlag.GetAttribute("src")).Value);
        }
    }
}
