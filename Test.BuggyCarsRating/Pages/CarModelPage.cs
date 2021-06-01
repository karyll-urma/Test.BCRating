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
    public class CarModelPage:BasePage
    {
        public CarModelPage(DriverContext driverContext) : base(driverContext)
        {

        }

        IWebElement btnVote => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Vote!']"));
        IWebElement txtAreaComment => _driverContext.Driver.FindElement(By.XPath("//label[contains(text(),'Your Comment')]/following-sibling::textarea"));
        IWebElement txtVoteCount => _driverContext.Driver.FindElement(By.XPath("//h4[contains(text(),'Votes:')]/strong"));

        // Add comment and click vote
        public void AddCommentAndVote(string comment)
        {
            txtAreaComment.SendKeys(comment);
            btnVote.Click();

            // Loop to verify vote is added
            for(int iCnt = 1; iCnt <= 5; iCnt++)
            {
                if (IsVoteAdded().Equals(true))
                {
                    break;
                }
            }
        }
        
        // Get vote count
        public int GetVoteCount()
        {
            return Int32.Parse(txtVoteCount.Text.Trim());
        }

        // Return true if vote is added
        public bool IsVoteAdded()
        {
            return _customControlHelper.IsElementDisplayed("p", "Thank you for your vote!");
        }
    }
}
