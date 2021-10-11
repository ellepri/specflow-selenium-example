using System.Collections.Generic;
using OpenQA.Selenium;

namespace SpecFlowProjectExample.PageObjects
{
    public class Homepage : BasePage
    {
        public Homepage(IWebDriver driver) : base(driver) { }
        
        public IWebElement ProgrammesCount => Driver.FindElement(By.CssSelector(".home-intro span"));
        public IWebElement CountLabel => Driver.FindElement(By.CssSelector(".home-intro p"));
        public IWebElement Masthead => Driver.FindElement(By.CssSelector(".br-masthead__pagetitle"));
        public IWebElement HomepageDescription => Driver.FindElement(By.CssSelector(".text--prose"));
        public IEnumerable<IWebElement> ServiceHeadings => Driver.FindElements(By.CssSelector("#services h3"));
        public IEnumerable<IWebElement> Services => Driver.FindElements(By.CssSelector("#services a"));

        public void NavigateToHomepage()
        {
            Navigate("https://www.bbc.co.uk/programmes");
        }

        public void ClickService(string serviceName)
        {
            foreach (var element in Services)
            {
                if (!serviceName.Equals(element.Text)) continue;
                element.Click();
                break;
            }
        }
    }
}
