using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.PageObjects
{
    class Payees_Page
    {


        private IWebDriver driver;
        private WebDriverWait wait;
        public Payees_Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
  
        }


        IWebElement addBtnMain => driver.FindElement(By.CssSelector(".Button > .Language__container"));

        IWebElement alertMessage => driver.FindElement(By.CssSelector(".inner.js-notification"));

        IList<IWebElement> payeeList => driver.FindElements(By.XPath("//*[@class='js-payee-name']"));

        IWebElement payeeNameListTitle => driver.FindElement(By.XPath("//span[normalize-space()='Name']"));

        public void clickAddBtn()
        {
            addBtnMain.Click();
        }

        

        public string getAlertText()
        {
            //IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".inner.js-notification")));
            return alertMessage.Text.ToString();
        }

        public bool elementValidationInPage(string name)
        {
            return driver.PageSource.Contains(name);
        }

        public void clickNameTitle()
        {
            payeeNameListTitle.Click();
        }
       
        public IList<IWebElement> getPayeeList()
        {
            return payeeList;
        }



    }
}
