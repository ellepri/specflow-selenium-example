using System;
using SpecFlowProjectExample.Support;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProjectExample.Steps
{
    [Binding]
    public class SchedulePageSteps
    {
        private readonly PageFactory _pageFactory;

        public SchedulePageSteps(PageFactory pageFactory) => _pageFactory = pageFactory;

        [Then(@"'(.*)' links to the (.*) schedule page")]
        public void ThenLinksToTheSchedulePage(string linkName, string destination)
        {
            var cYear = DateTime.Today.Year;
            var cMonth = DateTime.Today.Month.ToString("d2");
            _pageFactory.SchedulePage.ClickSchedule(linkName);
            var expectedPath = destination switch
            {
                "monthly" => cYear + "/" + cMonth,
                "weekly" => cYear + "/" + "w",
                _ => throw new ArgumentOutOfRangeException(nameof(destination), destination, null)
            };

            Assert.Contains(expectedPath, _pageFactory.SchedulePage.GetCurrentUrl());
        }

        [Then(@"broadcast item links to the broadcast's episode page")]
        public void ThenBroadcastItemLinksToTheBroadcastsEpisodePage()
        {
            var broadcastItem = _pageFactory.SchedulePage.BroadcastItems[0];
            broadcastItem.Click();
        }
    }
}
