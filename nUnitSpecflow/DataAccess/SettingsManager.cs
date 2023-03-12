using NUnit.Framework;

namespace nUnitSpecflow.DataAccess
{
    internal static class SettingsManager
    {
        public static string WebBrowser => TestContext.Parameters["webBrowser"] ?? String.Empty;

        public static bool HeadlessEnabled => TestContext.Parameters["headlessEnabled"].ToLower().Equals("true");
    }
}
