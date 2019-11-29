using System;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void CreateNewOpportunity()
        //{
        //    Pages.HomePage.GoTo();
        //    Assert.IsTrue(Pages.HomePage.IsAt());
        //}

        //[TestMethod]
        //public void CanGoToCreatedOpportunity()
        //{
        //    Pages.HomePage.GoTo();
        //    Pages.HomePage.SelectOpportunity("Opp Name");
        //    Assert.IsTrue(Pages.HomePage.IsAtOpportunityPage("Opp Name"));
        //}
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            driver = new ChromeDriver();
            //baseURL = "https://www.katalon.com/";
            driver.Manage().Window.Maximize();

        }
        //[TestMethod]
        //public void TheUntitledTestCaseTest()
        //{
        //    driver.Navigate().GoToUrl("https://bulls-quoting.profitoptics.com/Account/Account/Login?ReturnUrl=%2F");
        //    driver.FindElement(By.Id("Email")).Click();
        //    driver.FindElement(By.Id("Email")).Clear();
        //    driver.FindElement(By.Id("Email")).SendKeys("milorad.petrovic@profitoptics.com");
        //    driver.FindElement(By.Id("Password")).Clear();
        //    driver.FindElement(By.Id("Password")).SendKeys("Milorad1!");
        //    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Remember me?'])[1]/following::input[1]")).Click();
        //    driver.FindElement(By.LinkText("Pipeline Manager")).Click();
        //    driver.FindElement(By.Id("add-opportunity")).Click();
        //}

        [TestMethod]
        public void CreateOpportunity()
        {
            driver.Navigate().GoToUrl("https://bulls-quoting.profitoptics.com/Account/Account/Login?ReturnUrl=%2F");
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("milorad.petrovic@profitoptics.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Milorad1!");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Remember me?'])[1]/following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Win/Loss'])[1]/following::span[1]")).Click();
            driver.FindElement(By.Id("add-opportunity")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("opportunity-title")).Click();
            driver.FindElement(By.Id("opportunity-title")).Clear();
            driver.FindElement(By.Id("opportunity-title")).SendKeys("automatedTest");
            driver.FindElement(By.Id("quote-form")).Click();
            new SelectElement(driver.FindElement(By.Id("quote-form"))).SelectByText("Sales");
            driver.FindElement(By.Id("quote-form")).Click();
            driver.FindElement(By.Name("customerIsSelected")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Filter'])[2]/following::button[1]")).Click();
        }

        [TestMethod]
        public void EditOpportunity()
        {
            driver.Navigate().GoToUrl("https://bulls-quoting.profitoptics.com/Account/Account/Login?ReturnUrl=%2F");
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("milorad.petrovic@profitoptics.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Milorad1!");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Remember me?'])[1]/following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Win/Loss'])[1]/following::span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Search:'])[1]/input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Search:'])[1]/input[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Search:'])[1]/input[1]")).SendKeys("automatedTest2");
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("automatedTest2")).Click();
            driver.FindElement(By.Name("ExpectedCloseDate")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sa'])[1]/following::td[19]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Notes'])[1]/following::textarea[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Notes'])[1]/following::textarea[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Notes'])[1]/following::textarea[1]")).SendKeys("automated test note");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='no'])[4]/following::input[1]")).Click();
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Supply Sales $ Potential (Annual)'])[2]/following::input[1]")).Click();
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Supply Sales $ Potential (Annual)'])[2]/following::input[1]")).Clear();
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Supply Sales $ Potential (Annual)'])[2]/following::input[1]")).SendKeys("1");
            
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Browser.Close();
        }
    }
}
