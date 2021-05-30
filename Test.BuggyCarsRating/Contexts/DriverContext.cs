using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Base;

namespace Test.BuggyCarsRating.Contexts
{
    public class DriverContext
    {
        public IWebDriver Driver { get; set; }
        public Browser browser { get; set; }
    }
}
