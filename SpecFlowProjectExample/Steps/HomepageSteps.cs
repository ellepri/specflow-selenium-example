using System;
using System.Linq;
using SpecFlowProjectExample.Support;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProjectExample.Steps
{
    [Binding]
    public class HomepageStepDefinitions
    {
        private readonly PageFactory _pageFactory;

        public HomepageStepDefinitions(PageFactory pageFactory) => _pageFactory = pageFactory;

        [Given(@"I am on the programmes homepage")]
        public void GivenIAmOnTheProgrammesHomepage()
        {
            _pageFactory.Homepage.NavigateToHomepage();
        }
        
        [Then(@"the page title is set in the html header to '(.*)'")]
        public void ThenThePageTitleIsSetInTheHtmlHeaderTo(string headerTitle)
        {
            Assert.Equal(_pageFactory.Homepage.PageTitle, headerTitle);
        }

        [Then(@"the masthead title is '(.*)'")]
        public void ThenTheMastheadTitleIs(string mastheadTitle)
        {
            Assert.Equal(_pageFactory.Homepage.Masthead.Text, mastheadTitle);
        }
        
        [Then(@"the total number of programmes in PIPs is displayed")]
        public void ThenTheTotalNumberOfProgrammesInPiPsIsDisplayed()
        {
            Assert.Matches("(^\\d+(,\\d+)*$)",_pageFactory.Homepage.ProgrammesCount.Text);
        }

        [Then(@"it is followed by the text '(.*)'")]
        public void ThenItIsFollowedByTheText(string countLabel)
        {
            Assert.Contains(countLabel, _pageFactory.Homepage.CountLabel.Text);
        }

        [Then(@"the intro text is displayed")]
        public void ThenTheIntroTextIsDisplayed()
        {
            Assert.True(_pageFactory.Homepage.HomepageDescription.Displayed);
        }

        [Then(@"the below service type headings are displayed")]
        public void ThenTheBelowServiceTypeHeadingsAreDisplayed(Table table)
        {
            var expectedValues = table.Rows.Select(r => r[0]);
            var actualValues = _pageFactory.Homepage.ServiceHeadings.Select(iw => iw.Text);
            Assert.Equal(expectedValues, actualValues);
        }

        [Then(@"I go to the schedule page (.*)")]
        public void ThenIGoToTheSchedulePage(string url)
        {
            var uriAbsolutePath = new Uri(_pageFactory.Homepage.GetCurrentUrl()).AbsolutePath;
            Assert.Equal(url, uriAbsolutePath);
        }

        [When(@"I select the service (.*)")]
        public void WhenISelectTheService(string service)
        {
            _pageFactory.Homepage.ClickService(service);
        }

        [Then(@"I am on service schedule page")]
        public void ThenIAmOnServiceSchedulePage()
        {
            Assert.Contains("Schedules", _pageFactory.SchedulePage.PageTitle);
        }
    }
}
