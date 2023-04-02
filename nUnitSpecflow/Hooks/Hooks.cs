using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            List<string> ignoreLabels = GetIgnoreTagLabels();
            if (0 < ignoreLabels.Count) 
            {
                Assert.Ignore($"Ignoring per issue(s) reported on {string.Join(", ", ignoreLabels)}.");
            }
        }

        [AfterScenario]
        public void Teardown()
        {
            _myDriverManager.Quit();
        }

        List<string> GetIgnoreTagLabels()
        {
            List<string> ignoreTags = _scenarioContext.ScenarioInfo.Tags.Where(x => x.Contains("ignore")).ToList();
            List<string> labels = new List<string>();
            if (0 < ignoreTags.Count)
            {
                var ticketRegex = new Regex("[0-9]+");
                foreach (var ignoreTag in ignoreTags)
                {
                    labels.AddRange(ticketRegex.Matches(ignoreTag).Select(x => x.Value));

                }
            }
            return labels;
        }
    }
}
