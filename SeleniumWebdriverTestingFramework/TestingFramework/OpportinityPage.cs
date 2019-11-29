using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestingFramework
{
    public class OpportinityPage
    {
        [FindsBy(How = How.CssSelector, Using = "CSS selector goes here")]
        private IWebElement opportunityName;

        public string OpportunityName
        {
            get { return opportunityName.Text;}
        }
    }
}