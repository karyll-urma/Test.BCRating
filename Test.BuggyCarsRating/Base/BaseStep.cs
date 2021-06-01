using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Test.BuggyCarsRating.Contexts;
using Test.BuggyCarsRating.Helpers;
using Test.BuggyCarsRating.Pages;

namespace Test.BuggyCarsRating.Base
{
    public abstract class BaseStep
    {
        public DriverContext _driverContext;
        public HomePage _homePage;
        public LoginPage _loginPage;
        public RegisterPage _registerPage;
        public CodeHelper _codeHelper;
        public CarModelPage _carModelPage;
        //public NavigationHelper _navigationHelper;
        public ScenarioContext _scenarioContext;
        public TestContext _testContext;

        public BaseStep(DriverContext driverContext,ScenarioContext scenarioContext, TestContext testContext)
        {
            _driverContext = driverContext;
            _loginPage = new LoginPage(_driverContext);
            _registerPage = new RegisterPage(_driverContext);
            _homePage = new HomePage(_driverContext);
            _codeHelper = new CodeHelper(_driverContext);
            _carModelPage = new CarModelPage(_driverContext);
            //_navigationHelper = new NavigationHelper(_driverContext);

            this._scenarioContext = scenarioContext;
            this._testContext = testContext;
        }
    }
}
