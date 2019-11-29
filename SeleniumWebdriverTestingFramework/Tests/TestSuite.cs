using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BullsMTests
{
    [TestClass]
    public class TestSuite
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
            //baseURL = "https://www.katalon.com/";
            driver.Manage().Window.Maximize();

        }

        [TestMethod]
        public void TheEditOpportunityTest()
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
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Supply Sales $ Potential (Annual)'])[2]/following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Supply Sales $ Potential (Annual)'])[2]/following::input[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Supply Sales $ Potential (Annual)'])[2]/following::input[1]")).SendKeys("1");

        }
    }
}
