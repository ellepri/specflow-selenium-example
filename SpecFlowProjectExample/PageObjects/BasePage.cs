using OpenQA.Selenium;

namespace SpecFlowProjectExample.PageObjects
{
    public class BasePage
    {
        protected BasePage(IWebDriver driver) => Driver = driver;

        protected IWebDriver Driver { get; }
        public string PageTitle => Driver.Title;

        protected void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        
        public string GetCurrentUrl()
        {
            return Driver.Url;
        }
    }
}
