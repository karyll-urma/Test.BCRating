using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Steps
{
    [Binding]
    public class LoginFeatureSteps : BaseStep
    {
        public LoginFeatureSteps(DriverContext driverContext, ScenarioContext scenarioContext, TestContext testContext) : base(driverContext, scenarioContext, testContext)
        {

        }
        
        [When(@"User login using credentials")]
        public void WhenUserLoginUsingCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            // Enter Login and Password, then Click login.
            _loginPage.EnterLoginAndPassword(data.Login, data.Password);
            _loginPage.ClickLogin();

            // store credentials to scenarioContext
            _scenarioContext.Set(data.Login, "login");
            _scenarioContext.Set(data.Password, "password");
        }

        [When(@"User login in the application")]
        public void WhenUserLoginInTheApplication()
        {                      
            // Enter Login and Password, then Click login.
            _loginPage.EnterLoginAndPassword(_scenarioContext.Get<string>("reglogin"), _scenarioContext.Get<string>("regpassword"));
            _loginPage.ClickLogin();

            // store credentials to scenarioContext
            _scenarioContext.Set(_scenarioContext.Get<string>("reglogin"), "login");
            _scenarioContext.Set(_scenarioContext.Get<string>("regpassword"), "password");
        }


        [Then(@"User successfully logged in")]
        public void ThenUserSuccessfullyLoggedIn()
        {
            Assert.IsTrue(_homePage.IsLogoutDisplayed(), "=====> User " + _scenarioContext.Get<string>("login") + " not successfully logged in.");
        }

        [Then(@"User not successfully logged in")]
        public void ThenUserNotSuccessfullyLoggedIn()
        {
            Assert.IsFalse(_homePage.IsLogoutDisplayed(), "=====> User " + _scenarioContext.Get<string>("login") + " successfully logged in.");
        }

        [Then(@"User able to see homepage")]
        public void ThenUserAbleToSeeHomepage()
        {
            Assert.IsTrue(_homePage.IsHomePageDisplayed(), "=====> Homepage not displayed.");
        }

        [Then(@"User able to see message Invalid username/password")]
        public void ThenUserAbleToSeeMessageInvalidUsernamePassword()
        {
            Assert.IsTrue(_homePage.IsInvalidUserPasswordDisplayed(), "=====> Homepage not displayed.");
        }


    }
}
