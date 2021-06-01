using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(DriverContext driverContext) : base(driverContext)
        {

        }

        IWebElement TextRegister => _driverContext.Driver.FindElement(By.XPath("//h2[text() = 'Register with Buggy Cars Rating']"));
        IWebElement BtnRegisterRegPg => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Register']"));
        IWebElement BtnCancelRegPg => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Cancel']"));


        // Validate 'Register with Buggy Cars Rating' page is displayed
        public bool IsRegisterPageDisplayed()
        {
            return TextRegister.Displayed;
        }

        // Enter Login, First Name, Last Name
        public void EnterLoginFirstNameLastName(string Login, string FirstName, string LastName)
        {
            _customControlHelper.InputText("username", "id", Login);
            _customControlHelper.InputText("firstName", "id", FirstName);
            _customControlHelper.InputText("lastName", "id", LastName);
        }

        // Enter Login, First Name, Last Name(Work Around)
        public void EnterLoginFirstNameLastNameWorkAround(string Login, string FirstName, string LastName)
        {
            _customControlHelper.InputTextWorkAround("username", "id", Login);
            _customControlHelper.InputTextWorkAround("firstName", "id", FirstName);
            _customControlHelper.InputTextWorkAround("lastName", "id", LastName);
        }

        // Enter Password, Confirm Password
        public void EnterPasswordConfirmPassword(string Password, string ConfirmPassword)
        {
            _customControlHelper.InputText("password", "id", Password);
            _customControlHelper.InputText("confirmPassword", "id", ConfirmPassword);
        }

        // Enter Password, Confirm Password(Work Around)
        public void EnterPasswordConfirmPasswordWorkAround(string Password, string ConfirmPassword)
        {
            _customControlHelper.InputTextWorkAround("password", "id", Password);
            _customControlHelper.InputTextWorkAround("confirmPassword", "id", ConfirmPassword);
        }

        // Click Register
        public void ClickRegisterRegPg()
        {
            BtnRegisterRegPg.Click();
        }

        // Click Cancel
        public void ClickCancelRegPg()
        {
            BtnCancelRegPg.Click();
        }

        // Return Alerts
        public string TextResultAlert()
        {
            try
            {
                return _customControlHelper.TextMessage("result alert").Trim();
            }
            catch (Exception)
            {
                return _customControlHelper.TextMessage("alert alert").Trim();
            }
        }
    }
}
