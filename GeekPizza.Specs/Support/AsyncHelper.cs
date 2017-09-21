using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GeekPizza.Specs.Support
{
    [Binding]
    public class AsyncHelper : Steps
    {
        [BeforeScenarioBlock("mobile")]
        public void WaitBeforeAssertions()
        {
            if (ScenarioContext.CurrentScenarioBlock != ScenarioBlock.Then)
                return;
            Console.WriteLine("Waiting a bit...");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
