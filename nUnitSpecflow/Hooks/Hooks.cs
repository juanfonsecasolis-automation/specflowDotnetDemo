using NUnit.Framework;
using nUnitSpecflow.Pages;
using nUnitSpecflow.Steps;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]

namespace nUnitSpecflow.Hooks
{
    [Binding]
    public class Hooks
    {
        private ScenarioContext _scenarioContext;
        private MyDriverManager _myDriverManager;
        private ISpecFlowOutputHelper _outputHelper;

        public Hooks(
            FeatureContext featureContext,
            ScenarioContext scenarioContext,
            ISpecFlowOutputHelper outputHelper
        )
        {
            _scenarioContext = scenarioContext;
            _outputHelper = outputHelper;
            if (featureContext.FeatureInfo.Tags.Contains(BaseSteps.UiTestLabel))
            {
                _myDriverManager = featureContext.Get<MyDriverManager>(
                    ContextKeys.MyWebDriver.ToString()
                );
            }
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (featureContext.FeatureInfo.Tags.Contains(BaseSteps.UiTestLabel))
            {
                featureContext.Add(ContextKeys.MyWebDriver.ToString(), new MyDriverManager());
            }
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            if (featureContext.FeatureInfo.Tags.Contains(BaseSteps.UiTestLabel))
            {
                featureContext.Get<MyDriverManager>(ContextKeys.MyWebDriver.ToString()).Quit();
            }
        }

        [BeforeScenario]
        public void Setup()
        {
            List<string> ignoreLabels = GetIgnoreTagLabels();
            if (0 < ignoreLabels.Count)
            {
                Assert.Ignore(
                    $"Ignoring per issue(s) reported on {string.Join(", ", ignoreLabels)}."
                );
            }
        }

        [AfterScenario]
        public void Teardown(ScenarioContext scenarioContext)
        {
            if (scenarioContext.ScenarioInfo.ScenarioAndFeatureTags.Contains(BaseSteps.UiTestLabel))
            {
                // take a snapshot if an error ocurred
                if (_scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
                {
                    string filename = _myDriverManager.CaptureSnapshot();
                    _outputHelper.AddAttachment(filename);
                }

                // log off
                try
                {
                    new InventoryPage(_myDriverManager).LogOut();
                }
                catch
                {
                    TestContext.WriteLine("Skipping logout.");
                }
            }
        }

        List<string> GetIgnoreTagLabels()
        {
            List<string> ignoreTags = _scenarioContext.ScenarioInfo.Tags
                .Where(x => x.Contains("ignore"))
                .ToList();
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
