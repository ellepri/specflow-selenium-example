using OpenQA.Selenium;
using SpecFlowProjectExample.Drivers;
using SpecFlowProjectExample.PageObjects;

namespace SpecFlowProjectExample.Support
{
    public class PageFactory
    {
        public PageFactory()
        {
            Driver = new Driver().Current;
            Homepage = new Homepage(Driver);
            SchedulePage = new SchedulePage(Driver);
        }
        
        public IWebDriver Driver { get; }
        public Homepage Homepage { get; }
        public SchedulePage SchedulePage { get; }
        
    }
}
