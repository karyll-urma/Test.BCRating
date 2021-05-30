using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Helpers
{
    public class CustomControlHelper:BaseHelper
    {
        public CustomControlHelper(DriverContext driverContext) : base(driverContext)
        {

        }
        // Enter text on a given ControlName id
        public void InputText(string ControlName, string Value)
        {
            IWebElement InputControl = _driverContext.Driver.FindElement(By.XPath($"//input[@id = '{ControlName}']"));
            InputControl.SendKeys(Value);
        }

        public void InputTextWorkAround(string ControlName, string Value)
        {
            IWebElement InputControl = _driverContext.Driver.FindElement(By.XPath($"//input[@id = '{ControlName}']"));
            InputControl.SendKeys("-");
            InputControl.SendKeys(Keys.Backspace);
            InputControl.SendKeys(Value);
        }

        // Return Text Message on a given TextType class
        public string TextMessage(string TextType)
        {
            IWebElement TextMsg = _driverContext.Driver.FindElement(By.XPath($"//div[contains(@class,'{TextType}')and not(@hidden)]"));
            return TextMsg.Text;
        }
    }
}
