using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.PageObjects
{
    class AddPayee_Page
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        public AddPayee_Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        IWebElement payeeNametxtbox => driver.FindElement(By.CssSelector("#ComboboxInput-apm-name"));
        IWebElement suggestionLink => driver.FindElement(By.XPath("//span[@title='Someone new: name']"));
        IWebElement banktxtbox => driver.FindElement(By.CssSelector("#apm-bank"));
        IWebElement branchtxtbox => driver.FindElement(By.CssSelector("#apm-branch"));
        IWebElement accounttxtbox => driver.FindElement(By.CssSelector("#apm-account"));
        IWebElement suffixtxtbox => driver.FindElement(By.CssSelector("#apm-suffix"));
        IWebElement addBtnWindow => driver.FindElement(By.CssSelector(".js-submit"));

        IWebElement errorMessage => driver.FindElement(By.CssSelector(".error-header"));

        public void fillPayeeName(String name)
        {
            payeeNametxtbox.SendKeys(name);
        }

        public void clickOnsuggestionLink(String name)
        {
            //IWebElement suggestionLink = driver.FindElement(By.XPath("//span[@title='Someone new: " + name + "']"));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@title='Someone new: " + name + "']")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
            //suggestionLink.Click();
        }


        public void fillBankCode(string bankcode)
        {
            banktxtbox.Clear();
            banktxtbox.SendKeys(bankcode);
        }

        public void fillBranchCode(String branchcode)
        {
            branchtxtbox.Clear();
            branchtxtbox.SendKeys(branchcode);
        }

        public void fillAccountCode(String accountcode)
        {
            accounttxtbox.Clear();
            accounttxtbox.SendKeys(accountcode);
        }

        public void fillSuffix(String suffix)
        {
            suffixtxtbox.Clear();
            suffixtxtbox.SendKeys(suffix);
        }

        public void clickAddBtnInWindow()
        {
            addBtnWindow.Click();
        }

        public String getErrorMessage()
        {

            return errorMessage.Text.ToString();
        }

        public int isErrorMessageAvailable()
        {
            List<IWebElement> e = new List<IWebElement>();
            e.AddRange(driver.FindElements(By.CssSelector(".error-header")));
            return e.Count;
        }

        public bool elementValidationInPage(string name)
        {
            return driver.PageSource.Contains(name);
        }

    }
}
