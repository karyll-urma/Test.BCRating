using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Helpers
{
    public class NavigationHelper : BaseHelper
    {
        public NavigationHelper(DriverContext driverContext) : base(driverContext)
        {

        }

        IWebElement nextButton => _driverContext.Driver.FindElement(By.XPath("//input[@class = 'form-control input-xs ng-untouched ng-pristine ng-valid']/following-sibling::a[@class = 'btn']"));

        // Find and navigate to make model
        public void FindAndNavigateToModel(string model)
        {
            IWebElement pageIndicator = _driverContext.Driver.FindElement(By.XPath($"//my-pager//div[@class = 'pull-xs-right']"));
            
            // Get current and max page
            int currentPage = Int32.Parse(pageIndicator.Text.Trim().Split("of")[0].Split("page")[1].Trim());
            int maxPage = Int32.Parse(pageIndicator.Text.Trim().Split("of")[1]);

            // Loop until model is found
            for (int iCnt = 1; iCnt <= maxPage; iCnt++)
            {               
                if (IsXpathDisplayed($"//td/a[text() = '{model}']"))
                {
                    _driverContext.Driver.FindElement(By.XPath($"//td/a[text() = '{model}']")).Click();
                    break;
                }
                else if (iCnt == maxPage)
                {
                    Assert.Fail("=====> Model: " + model + " does not exist.");
                }
                else
                {
                    nextButton.Click();
                }
            }
        }

        // Return true if given xpath is displayed
        public bool IsXpathDisplayed(string xpath)
        {
            try
            {
                return _driverContext.Driver.FindElement(By.XPath($"{xpath}")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
