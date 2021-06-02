using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Contexts;
using static Test.BuggyCarsRating.Base.Browser;

namespace Test.BuggyCarsRating.Helpers
{
    public static class SettingsReaderHelper
    {
        // Set parameter values to Settings context
        public static void SetFrameworkSettings()
        {
            Settings.BaseUrl = TestContext.Parameters["baseUrl"].ToString();
            Settings.Browser = (BrowserType)Enum.Parse(typeof(BrowserType),TestContext.Parameters["browser"]);
            Settings.IsHeadless = bool.Parse(TestContext.Parameters["isHeadless"]);
            Settings.ImplicitWait = Int32.Parse(TestContext.Parameters["implicitWait"]);
        }       
    }
}
