using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        }
   
        IWebElement menuBtn => driver.FindElement(By.XPath("//span[contains(text(),'Menu')]"));

        //IWebElement everyDayPayee => driver.FindElement(By.XPath("//h3[contains(.,'Everyday')]"));

       //IWebElement billPayee => driver.FindElement(By.XPath("//h3[contains(.,'Bill')]"));

        IWebElement balanceAmmount => driver.FindElement(By.CssSelector(".js-account-current"));

        IWebElement closeButton => driver.FindElement(By.CssSelector(".js-close-modal-button"));

        IWebElement transferAlertMessage => driver.FindElement(By.CssSelector("span[role='alert']"));





        public void openHomePage(String URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        public MenuPage clickOnMenu()
        {
            menuBtn.Click();
            return new MenuPage(driver);
        }

        public void clickOnAPayeeItem(String PayeeName)
        {
            driver.FindElement(By.XPath("//h3[contains(.,'"+ PayeeName + "')]")).Click();
        }

        public String getBalanceAmount()
        {
            return balanceAmmount.Text.ToString();
        }

        public void closeDetailsWindow()
        {
            closeButton.Click();
        }

        public string getTransferAlertText()
        {
            return transferAlertMessage.Text.ToString();
        }

    }
}
