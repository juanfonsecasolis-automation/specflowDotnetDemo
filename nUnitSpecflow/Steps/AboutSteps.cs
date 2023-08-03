using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    internal class AboutSteps : BaseSteps
    {
        const int SLEEP_MILLISECONDS_MISSING_RESPONSE_STATUS = 1000;
        const int MAX_NUMBER_ATTEMPTS_READ_RESPONSE_STATUS = 5;

        public AboutSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(featureContext, scenarioContext) { }

        [Given(@"user starts intercepting network traffic")]
        public void GivenUserStartsInterceptingNetworkTraffic()
        {
            MyDriverManager.StartInterceptingNetworkTraffic();
        }

        [Then(@"user request ""([^""]*)"" completes with status ""([^""]*)""")]
        public void ThenUserRequestCompletesWithStatus(string requestUrl, int expectedStatusCode)
        {
            int attempt = 0;
            while (
                attempt++ < MAX_NUMBER_ATTEMPTS_READ_RESPONSE_STATUS
                && (
                    !MyDriverManager.ResponseStatusLog.ContainsKey(requestUrl)
                    || MyDriverManager.ResponseStatusLog[requestUrl] != 200
                )
            )
            {
                Thread.Sleep(SLEEP_MILLISECONDS_MISSING_RESPONSE_STATUS);
            }
            Assert.IsTrue(MyDriverManager.ResponseStatusLog.ContainsKey(requestUrl));
            Assert.That(MyDriverManager.ResponseStatusLog[requestUrl], Is.EqualTo(200));
        }
    }
}
