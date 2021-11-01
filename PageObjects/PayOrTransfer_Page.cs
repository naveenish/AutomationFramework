using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.PageObjects
{
    class PayOrTransfer_Page
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public PayOrTransfer_Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            
        }

        IWebElement transferFromBox => driver.FindElement(By.XPath("//span[contains(.,'Choose account')]"));

        IWebElement searchTextbox => driver.FindElement(By.CssSelector("input[placeholder='Search']"));


        IWebElement transferFromFirstElement => driver.FindElement(By.XPath("//p[text()='Everyday']"));

        IWebElement transferToBox => driver.FindElement(By.XPath("//span[contains(.,'Choose account, payee, or someone new')]"));

        IWebElement transferToFirstElement => driver.FindElement(By.XPath("//p[text()='Bills ']"));

        IWebElement amountTextbox => driver.FindElement(By.XPath("//input[@name='amount']"));

        IWebElement transferBtn => driver.FindElement(By.XPath("//span[contains(@class,'Language__container')][normalize-space()='Transfer']"));


        public void clickOnTransferFromBox()
        {
            transferFromBox.Click();
        }

        public void searchPayee(String transferFromName)
        {
            searchTextbox.Clear();
            searchTextbox.SendKeys(transferFromName);
        }

        public void selectTransferFromFirstItem()
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath("//p[text()='Everyday']")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
   
            
        }

        public void clickOnTransferToBox()
        {
            transferToBox.Click();
        }

        public void selectTransferToFirstItem()
        {

            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath("//p[text()='Bills ']")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
        }

        public void addTransferAmount(String amount)
        {
            amountTextbox.Clear();
            amountTextbox.SendKeys(amount);
        }

        public void clickOnTransferBtn()
        {
            transferBtn.Click();
        }


    }
}
