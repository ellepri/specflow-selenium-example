using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SpecFlowProjectExample.PageObjects
{
    public class SchedulePage : BasePage
    {
        public SchedulePage(IWebDriver driver) : base(driver) { }

        public ReadOnlyCollection<IWebElement> BroadcastItems =>
            Driver.FindElements(By.CssSelector(".programme__titles a"));

        public void ClickSchedule(string scheduleName)
        {
            if (scheduleName == "Calendar") scheduleName = "this_month";
            var attributeValue = scheduleName.ToLower().Replace(" ", "_");
            Driver.FindElement(By.CssSelector($"#schedule-header a[href*='{attributeValue}']")).Click();
        }
    }
}
