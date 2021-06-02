using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;

namespace Test.BuggyCarsRating.Steps
{
    [Binding]
    public class VoteFeatureSteps:BaseStep
    {
        public VoteFeatureSteps(DriverContext driverContext, ScenarioContext scenarioContext, TestContext testContext) : base(driverContext, scenarioContext, testContext)
        {

        }
        [When(@"User navigate to Make'(.*)' Model'(.*)'")]
        public void WhenUserNavigateToMakeModel(string make, string model)
        {
            // Navigate to make model 
            Assert.IsTrue(_homePage.NavigateToMakeModel(make, model),"=====> Make and model not matched");
        }
        
        [When(@"User input a comment '(.*)' and Vote")]
        public void WhenUserInputACommentAndVote(string comment)
        {
            // Store before vote count
            _scenarioContext.Set(_carModelPage.GetVoteCount(),"beforevote");

            // Comment and vote
            _carModelPage.AddCommentAndVote(comment);
        }


        [Then(@"User can see Vote counts increment by (.*)")]
        public void ThenUserCanSeeVoteCountsIncrementBy(int increment)
        {
            // Get before and after count
            int afterVoteCnt = _carModelPage.GetVoteCount();
            int beforeVoteCnt = _scenarioContext.Get<int>("beforevote");
            
            Console.WriteLine("Before Vote count: " + beforeVoteCnt);
            Console.WriteLine("After Vote count: " + afterVoteCnt);

            // Get difference and assert increment
            int difference = afterVoteCnt - beforeVoteCnt;
            Assert.That(difference.Equals(increment));
        }

        [Then(@"User will not be able to vote again on same car")]
        public void ThenUserWillNotBeAbleToVoteAgainOnSameCar()
        {
            Assert.IsFalse(_carModelPage.IsVoteButtonExist(), "=====> Vote button still active afer same user voted already.");
        }

        [When(@"User click logout link")]
        public void WhenUserClickLogoutLink()
        {
            _carModelPage.ClickLogout();
        }

        [Then(@"User is logged out successfully")]
        public void ThenUserIsLoggedOutSuccessfully()
        {
            Assert.False(_carModelPage.IsLogoutSuccessful(), "=====> Logout link is still visible.");
        }

        [Then(@"User exited the last transaction")]
        public void ThenUserExitedTheLastTransaction()
        {
            Assert.False(_carModelPage.IsVoteCountExist(), "=====> Last transaction is not exited after logging out.");
        }



    }
}
