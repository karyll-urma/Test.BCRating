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

        //IWebElement linkLogout => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Logout']"));
        //IWebElement linkProfile => _driverContext.Driver.FindElement(By.XPath("//a[text() = 'Profile']"));

        // Return true if logout is displayed
        public bool IsLogoutDisplayed()
        {
            return _customControlHelper.IsElementDisplayed("a", "Logout");
        }

        public bool IsHomePageDisplayed()
        {
            return _customControlHelper.IsElementDisplayed("h2", "Overall Rating");
        }

        public bool IsUserLoginDisplayed(string userLogin)
        {
            return _customControlHelper.IsElementDisplayed("span", "Hi " + userLogin);
        }

        public bool IsInvalidUserPasswordDisplayed()
        {
            return _customControlHelper.IsElementDisplayed("span", "Invalid username/password");
        }
    }
}
