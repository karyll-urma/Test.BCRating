using System;
using System.Collections.Generic;
using System.Text;
using static Test.BuggyCarsRating.Base.Browser;

namespace Test.BuggyCarsRating.Contexts
{
    public class Settings
    {
        public static string BaseUrl { get; set; }

        public static BrowserType Browser { get; set; }

        public static bool IsHeadless { get; set; }

        public static int ImplicitWait { get; set; }
    }
}
