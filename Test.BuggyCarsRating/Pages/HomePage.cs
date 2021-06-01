using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(DriverContext driverContext) : base(driverContext)
        {

        }

        IWebElement linkLogout => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Logout']"));
        IWebElement linkProfile => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Profile']"));
        IWebElement linkBuggyRating => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Buggy Rating']"));
        IWebElement linkOverAllRating => _driverContext.Driver.FindElement(By.XPath("//a[@href = '/overall']"));
        IWebElement text => _driverContext.Driver.FindElement(By.XPath("//input[@class = 'form-control input-xs ng-untouched ng-pristine ng-valid']/following-sibling::text()[2]"));


        // Return true if logout is displayed
        public bool IsLogoutDisplayed()
        {
            return _customControlHelper.IsElementDisplayed("a", "Logout");
        }

        // Return true if homepage is displayed
        public bool IsHomePageDisplayed()
        {
            return _customControlHelper.IsElementDisplayed("h2", "Overall Rating");
        }

        // Return true if User is displayed
        public bool IsUserLoginDisplayed(string userLogin)
        {
            return _customControlHelper.IsElementDisplayed("span", "Hi " + userLogin);
        }

        // Return true if Invalid username/password logout is displayed
        public bool IsInvalidUserPasswordDisplayed()
        {
            return _customControlHelper.IsElementDisplayed("span", "Invalid username/password");
        }

        // Click Logout button
        public void ClickLogout()
        {
            linkLogout.Click();
        }

        // Navigate to make model
        public void NavigateToMakeModel(string make, string model)
        {
            // Go to homepage
            linkBuggyRating.Click();
            IsHomePageDisplayed();

            // Select make model
            linkOverAllRating.Click();

            // Navigate to model
            _navigationHelper.FindAndNavigateToModel(model);

            // Verify if correct make
            
        }
    }
}
