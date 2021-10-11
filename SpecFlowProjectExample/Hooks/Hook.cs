using BoDi;
using OpenQA.Selenium.Support.Extensions;
using SpecFlowProjectExample.Support;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace SpecFlowProjectExample.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs(new PageFactory());
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext context)
        {
            _objectContainer.Resolve<PageFactory>().Driver.Dispose();
        }
    }
}
