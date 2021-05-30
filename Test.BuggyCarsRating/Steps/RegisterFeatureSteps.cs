﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Steps
{
    [Binding]
    public class RegisterFeatureSteps : BaseStep
    {

        public RegisterFeatureSteps(DriverContext driverContext, ScenarioContext scenarioContext, TestContext testContext) : base(driverContext, scenarioContext, testContext)
        {

        }

        [Given(@"User navigate to application")]
        public void GivenUserNavigateToApplication()
        {
            _driverContext.Driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }

        [When(@"User select Register button")]
        public void WhenUserSelectRegisterButton()
        {
            // Click Register and Validate Registration page is displayed.
            _loginPage.ClickRegister();
            Assert.IsTrue(_registerPage.IsRegisterPageDisplayed());
        }


        [When(@"User enter user credential")]
        public void WhenUserEnterUserCredential(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string loginOverride = "";

            //overide Login(for regression)
            if (data.Login.Contains("RandomString-"))
            {
                int length = Int32.Parse(data.Login.Split('-')[1]);
                loginOverride = _codeHelper.RandomString("AlphaNumeric", length);
            }
            else
            {
                loginOverride = data.Login;
            }

            // Enter User Credential(Login, First Name, Last Name, Password)
            _registerPage.EnterLoginFirstNameLastName(loginOverride, data.FirstName, data.LastName);
            _registerPage.EnterPasswordConfirmPassword(data.Password, data.ConfirmPassword);

            _scenarioContext.Set(loginOverride, "login");
            _scenarioContext.Set(data.FirstName, "firstname");
            _scenarioContext.Set(data.LastName, "lastname");
            _scenarioContext.Set(data.Password, "password");
            _scenarioContext.Set(data.ConfirmPassword, "confirmpassword");
        }

        [When(@"User enter the same user")]
        public void WhenUserEnterTheSameUser()
        {
            string login = _scenarioContext.Get<string>("login");
            string firstName = _scenarioContext.Get<string>("firstname");
            string lastName = _scenarioContext.Get<string>("lastname");
            string password = _scenarioContext.Get<string>("password");
            string confirmPassword = _scenarioContext.Get<string>("confirmpassword");

            // Enter User Credential(Login, First Name, Last Name, Password)
            _registerPage.EnterLoginFirstNameLastName(login, firstName, lastName);
            _registerPage.EnterPasswordConfirmPassword(password, confirmPassword);
        }


        [When(@"User enter user credential - with workaround")]
        public void WhenUserEnterUserCredential_WithWorkaround(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string loginOverride = "";

            //overide Login(for regression)
            if (data.Login.Contains("RandomString-"))
            {
                int length = Int32.Parse(data.Login.Split('-')[1]);
                loginOverride = _codeHelper.RandomString("AlphaNumeric", length);
            }
            else
            {
                loginOverride = data.Login;
            }

            // Enter User Credential(Login, First Name, Last Name, Password)
            _registerPage.EnterLoginFirstNameLastNameWorkAround(loginOverride, data.FirstName, data.LastName);
            _registerPage.EnterPasswordConfirmPasswordWorkAround(data.Password, data.ConfirmPassword);
        }


        [When(@"User click register button")]
        public void WhenUserClickRegisterButton()
        {
            _registerPage.ClickRegisterRegPg();
        }

        [Then(@"User successfully registered to the application")]
        public void ThenUserSuccessfullyRegisteredToTheApplication()
        {
            Assert.AreEqual("Registration is successful", _registerPage.TextResultAlert(), "=====> Message: " + _registerPage.TextResultAlert());
        }

        [Then(@"User can see the message '(.*)'")]
        public void ThenUserCanSeeTheMessage(string message)
        {
            try
            {
                Assert.IsTrue(_registerPage.TextResultAlert().Contains(message), "=====> Message: " + _registerPage.TextResultAlert());
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("=====> No alert message displayed.");
            }
        }

    }
}
