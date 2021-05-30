using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(DriverContext driverContext) : base(driverContext)
        {

        }

        IWebElement TextLogin => _driverContext.Driver.FindElement(By.Name("login"));
        IWebElement TextPassword => _driverContext.Driver.FindElement(By.Name("password"));
        IWebElement BtnLogin => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Login']"));
        IWebElement BtnRegister => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Register']"));

        // Enter Login and Password
        public void EnterLoginAndPassword(string Login, string Password)
        {
            TextLogin.SendKeys(Login);
            TextPassword.SendKeys(Password);
        }

        // Click Login
        public void ClickLogin()
        {
            BtnLogin.Click();
        }

        // Click Register
        public void ClickRegister()
        {
            BtnRegister.Click();
        }
    }
}
