using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;
        public Browser(DriverContext driverContext)
        {
            _driver = driverContext.Driver;
        }

        //public BrowserType Type { get; set; }
        //public void GoToUrl(string url)
        //{
        //    _driver.Url = url;
        //}

        public enum BrowserType
        {
            InternetExplorer,
            FireFox,
            Chrome
        }
    }
}
