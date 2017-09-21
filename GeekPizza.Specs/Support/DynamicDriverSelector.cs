using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekPizza.Specs.Drivers;
using TechTalk.SpecFlow;

namespace GeekPizza.Specs.Support
{
    [Binding]
    public class DynamicDriverSelector : Steps
    {
        [BeforeScenario(Order = -100)]
        public void Init()
        {
            if (Environment.GetEnvironmentVariable("AUTOMODE") == "UI")
                ScenarioContext.ScenarioContainer.RegisterTypeAs<UiAppDriver, IAppDriver>();
            else
                ScenarioContext.ScenarioContainer.RegisterTypeAs<ViewModelAppDriver, IAppDriver>();
        }
    }
}
