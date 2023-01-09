using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Hooks
{
    [Binding]
    class Hooks
    {
        private ScenarioContext _scenarioContext;
        private MyDriverManager _myDriverManager;

        public Hooks(MyDriverManager myDriverManager, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myDriverManager = myDriverManager;
        }

        [BeforeScenario]
        public void Setup()
        {
            
        }

        [AfterScenario]
        public void Teardown()
        {
            _myDriverManager.Quit();
        }
    }
}
