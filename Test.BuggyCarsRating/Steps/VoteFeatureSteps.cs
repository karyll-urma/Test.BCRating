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
            _homePage.NavigateToMakeModel(make, model);
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
    }
}
