using NUnit.Framework;

namespace nUnitSpecflow.DataAccess
{
    internal static class SettingsManager
    {
        public static string WebBrowser => TestContext.Parameters["webBrowser"];

        public static bool HeadlessEnabled => TestContext.Parameters["headlessEnabled"].ToLower().Equals("true");

        public static double SecsTimeoutElementVisible => int.Parse(TestContext.Parameters["secsTimeoutElementVisible"]);
    }
}
