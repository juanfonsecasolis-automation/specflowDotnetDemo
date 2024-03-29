﻿using NUnit.Framework;
using RestSharp;

namespace nUnitSpecflow.DataAccess
{
    internal static class SettingsManager
    {
        public static string WebBrowser => TestContext.Parameters["webBrowser"];

        public static bool HeadlessEnabled =>
            TestContext.Parameters["headlessEnabled"].ToLower().Equals("true");

        public static double SecsTimeoutElementVisible =>
            int.Parse(TestContext.Parameters["secsTimeoutElementVisible"]);

        public static string Username => TestContext.Parameters["username"];

        public static string Password => TestContext.Parameters["password"];

        public static string ReqResUrl => TestContext.Parameters["reqResUrl"];
    }
}
