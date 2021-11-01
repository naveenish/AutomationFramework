using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.PageObjects
{
    class MenuPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        public MenuPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           
        }

        IWebElement payeesLink => driver.FindElement(By.CssSelector(".js-main-menu-payees .Language__container"));

        IWebElement payortransferLink => driver.FindElement(By.CssSelector(".js-main-menu-paytransfer .Language__container"));

        public Payees_Page clickPayeeLink()
        {
            payeesLink.Click();
            return new Payees_Page(driver);
        }


        public PayOrTransfer_Page clickPayOrTransferLink()
        {
            payortransferLink.Click();
            return new PayOrTransfer_Page(driver);
        }
    }
}
