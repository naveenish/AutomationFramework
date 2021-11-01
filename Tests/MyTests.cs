using AutomationFramework.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutomationFramework.PageObjects
{
    //[TestFixture(BrowserType.Chrome)]
    //[TestFixture(BrowserType.Edge)]
    //[TestFixture(BrowserType.Firefox)]
    // [Parallelizable(ParallelScope.All)]
    class MyTests
    {

        //public BrowserType browser;
        //public MyTests(BrowserType browser) : base(browser)
        //{
        //    this.browser = browser;
        //}



        IWebDriver driver;
        HomePage homePage;
        Payees_Page payeePage;
        AddPayee_Page addpayeePage;
        MenuPage menuPage;
        PayOrTransfer_Page payTransPage;

        string payeeOneName = "Everyday";
        string payeeTwoName = "Bill";
        string transfer_amount = "500";
        string payeeNameText = "samplePayee12345";
        string transferSuccessMessage = "Transfer successful";
        string payeeAddSuccessMessage = "Payee added";
        string emptyPayeeNameErrorMessage = "A problem was found. Please correct the field highlighted below.";
        string bankCode = "01";
        string branchCode = "0398";
        string suffixCode = "000";
        string accountCode = "0246579";


        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            menuPage = new MenuPage(driver);
            homePage = new HomePage(driver);
            payeePage = new Payees_Page(driver);
            addpayeePage = new AddPayee_Page(driver);
            payTransPage = new PayOrTransfer_Page(driver);
            homePage.openHomePage("https://www.demo.bnz.co.nz/client/");
        }



        [Test]
        public void AddPayeeTest()
        {
            //homePage.openHomePage("https://www.demo.bnz.co.nz/client/");
            AddNewPayee();
            Assert.IsTrue(payeePage.elementValidationInPage(payeeNameText));
        }

        [Test]
        public void errorMessageValidation()
        {
            //homePage.openHomePage("https://www.demo.bnz.co.nz/client/");
            homePage.clickOnMenu();
            menuPage.clickPayeeLink();
            payeePage.clickAddBtn();
            addpayeePage.clickAddBtnInWindow();
            Assert.AreEqual(emptyPayeeNameErrorMessage, addpayeePage.getErrorMessage());
            addpayeePage.fillPayeeName(payeeNameText);
            addpayeePage.clickOnsuggestionLink(payeeNameText);
            Assert.IsTrue(addpayeePage.isErrorMessageAvailable()==0);
        }

        [Test]
        public void sortingValidation()
        {
            //homePage.openHomePage("https://www.demo.bnz.co.nz/client/");
            AddNewPayee();
            Assert.IsTrue(isListSorted(payeePage.getPayeeList()));
            payeePage.clickNameTitle();
            Assert.IsFalse(isListSorted(payeePage.getPayeeList()));

        }

        [Test]
        public void navigateToPaymentsPage()
        {
            //homePage.openHomePage("https://www.demo.bnz.co.nz/client/");
            string everydayOriginalAmount = getBalanceAmount(payeeOneName);
            string billOriginalAmount = getBalanceAmount(payeeTwoName);


            homePage.clickOnMenu();
            menuPage.clickPayOrTransferLink();

            payTransPage.clickOnTransferFromBox();
            payTransPage.searchPayee(payeeOneName);
            payTransPage.selectTransferFromFirstItem();
            payTransPage.clickOnTransferToBox();
            payTransPage.searchPayee(payeeTwoName);
            payTransPage.selectTransferToFirstItem();

            payTransPage.addTransferAmount(transfer_amount);
            payTransPage.clickOnTransferBtn();
            Thread.Sleep(3000);
            Assert.AreEqual(transferSuccessMessage, homePage.getTransferAlertText());

            string everydayNewAmount = getBalanceAmount(payeeOneName);
            string billNewAmount = getBalanceAmount(payeeTwoName);

            Assert.IsFalse(everydayOriginalAmount == everydayNewAmount);
            Assert.IsFalse(billOriginalAmount == billNewAmount);

        }


        
        public void AddNewPayee()
        {
            homePage.clickOnMenu();
            menuPage.clickPayeeLink();
            payeePage.clickAddBtn();
            addpayeePage.fillPayeeName(payeeNameText);
            addpayeePage.clickOnsuggestionLink(payeeNameText);
            addpayeePage.fillBankCode(bankCode);
            addpayeePage.fillBranchCode(branchCode);
            addpayeePage.fillAccountCode(accountCode);
            addpayeePage.fillSuffix(suffixCode);
            addpayeePage.clickAddBtnInWindow();
            Thread.Sleep(3000);
            Assert.AreEqual(payeeAddSuccessMessage, payeePage.getAlertText());
        }


        public string getBalanceAmount(string PayeeName)
        {
            homePage.clickOnAPayeeItem(PayeeName);
            string balAmount = homePage.getBalanceAmount();
            homePage.closeDetailsWindow();
            return balAmount;
        }


        public bool isListSorted(IList<IWebElement> elements)
            {
            var actualList = new List<string>();
            foreach (IWebElement e in elements)
            {
                //System.Console.WriteLine(string.Join(", ", e.Text));
                actualList.Add(e.Text);
            }

            var newList = new List<string>(actualList); ;
            actualList.Sort();
            //Console.WriteLine(string.Join(", ", actualList));
            if (actualList.SequenceEqual(newList))
            {
                Console.WriteLine("the list is sorted");
                return true;
            }
            else
            {
                Console.WriteLine("the list is not sorted");
                return false;
                
            }
        }


        [TearDown]
        public void TearDownForTest()
        {
            driver.Close();
        }

        //[OneTimeTearDown]
        //public void TearDown()
        //{
        //    //driver.Quit();
        //    driver.Close();
        //}
    }
}
