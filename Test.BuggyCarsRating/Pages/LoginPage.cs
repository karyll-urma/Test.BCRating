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

        IWebElement btnLogin => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Login']"));
        IWebElement btnRegister => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Register']"));


        // Enter Login and Password
        public void EnterLoginAndPassword(string Login, string Password)
        {
            _customControlHelper.InputText("login", "name", Login);
            _customControlHelper.InputText("password", "name", Password);
        }

        // Click Login
        public void ClickLogin()
        {
            btnLogin.Click();
        }

        // Click Register
        public void ClickRegister()
        {
            btnRegister.Click();
        }
    }
}
