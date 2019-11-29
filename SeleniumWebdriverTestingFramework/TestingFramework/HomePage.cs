using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestingFramework
{
    public class HomePage
    {
        public void GoTo()
        {
            Browser.GoTo(Url);
        }

        private static string Url = "https://www.google.com/";
        private static string PageTitle = "Google";
        [FindsBy(How = How.LinkText, Using = "Opportunity")]
        private IWebElement opportunityLink;

        public bool IsAt()
        {
            return Browser.Title == PageTitle;
        }

        public void SelectOpportunity(string opportunityName)
        {
            opportunityLink.Click();
            var opportunity = Browser.Driver.FindElement(By.LinkText(opportunityName));
            opportunity.Click();
        }

        public bool IsAtOpportunityPage(string opportunityName)
        {
            var opportunityPage = new OpportinityPage();
            //PageFactory.InitElements(Browser.Driver, opportunityPage);
            return opportunityPage.OpportunityName == opportunityName;
        }
    }
}