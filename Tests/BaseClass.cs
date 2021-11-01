using AutomationFramework.PageObjects;
using Microsoft.Edge.SeleniumTools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    class BaseClass
    {
        public IWebDriver driver;
        //public HomePage homePage;
        //public Payees_Page payeePage;
        //public AddPayee_Page addpayeePage;
        //public MenuPage menuPage;
        //public PayOrTransfer_Page payTransPage;

        
        public BaseClass(BrowserType type)
        {
            driver = WebDriver(type);
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //menuPage = new MenuPage(driver);
            //homePage = new HomePage(driver);
            //payeePage = new Payees_Page(driver);
            //addpayeePage = new AddPayee_Page(driver);
            //payTransPage = new PayOrTransfer_Page(driver);
            //homePage.openHomePage("https://www.demo.bnz.co.nz/client/");
        }

        public enum BrowserType
        {
            IE11,
            Firefox,
            Chrome,
            Edge
        }

        [SetUp]
        public void SetUp()
        {

            //driver = new ChromeDriver();

        }

        public static IWebDriver WebDriver(BrowserType type)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    driver = ChromeDriver();
                    break;

                case BrowserType.Firefox:
                    driver = FirefoxDriver();
                    break;

                case BrowserType.Edge:
                    driver = EdgeDriver();
                    break;

                case BrowserType.IE11:
                    driver = IeDriver();
                    break;
            }

            return driver;
        }

        private static IWebDriver IeDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }

        private static IWebDriver ChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver();
            return driver;
        }

        private static IWebDriver FirefoxDriver()
        {
           
            FirefoxDriver driver = new FirefoxDriver();
            return driver;
        }

        private static IWebDriver EdgeDriver()
        {
            EdgeDriver driver = new EdgeDriver();
            return driver;
        }


    }
}
