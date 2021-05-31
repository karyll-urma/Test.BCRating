using NUnit.Framework;
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

        // Enter text on a given ControlName and attribute
        public void InputText(string ControlName,string attribute, string Value)
        {
            IWebElement InputControl = _driverContext.Driver.FindElement(By.XPath($"//input[@{attribute} = '{ControlName}']"));
            InputControl.SendKeys(Value);
        }
        
        // Enter text on a given ControlName and attribute - workaround enter "-", clear then add value
        public void InputTextWorkAround(string ControlName, string attribute, string Value)
        {
            IWebElement InputControl = _driverContext.Driver.FindElement(By.XPath($"//input[@{attribute} = '{ControlName}']"));
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

        // Return true if given attribute and text displayed
        public bool IsElementDisplayed(string node, string text)
        {
            try
            {
                return _driverContext.Driver.FindElement(By.XPath($"//{node}[contains(text(),'{text}')]")).Displayed;               
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

    }
}
