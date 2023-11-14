using NUnit.Framework;
using System.Xml.Linq;
using PnP.Framework.Modernization.Transform;
using Microsoft.SharePoint.News.DataModel;
using TechTalk.SpecFlow.Assist;
using TFLCodeChallengeSpecs.Contexts;
using TFLCodeChallengeSpecs.Pages;
using TFLCodeChallengeSpecs.Config;
using DocumentFormat.OpenXml.Wordprocessing;
using NUnit.Framework.Interfaces;

namespace TFLCodeChallengeSpecs.Steps
{
    [Binding]
    public class journeyPlannerSteps : StepBase

    {
        private DriverHelper _driverHelper;

        PlanAJourneyPage planAJourneyPage;
        JourneyResultsPage journeyResultsPage;

        //  Environment-specific settings
        private readonly Env _env;
        private readonly string journeyPlannerURL;

        public journeyPlannerSteps(Env env, DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

            planAJourneyPage = new PlanAJourneyPage(_driverHelper.Driver);
            journeyResultsPage = new JourneyResultsPage(_driverHelper.Driver);  

            _env = env;
            journeyPlannerURL = env.JourneyPlannerURL;
        }

        private void NavigateTo()
        {
            _driverHelper.Driver.Navigate().GoToUrl(journeyPlannerURL);
        }

        [Given(@"the user is on the journey planner page")]
        public void GivenTheUserIsOnTheJourneyPlannerPage()
        {
            NavigateTo();
        }

        [Given(@"the user provides a valid ""([^""]*)"" and ""([^""]*)""")]
        public void GivenTheUserProvidesAValidAnd(string source, string destination)
        {
            planAJourneyPage.EnterSourceDestination(source, destination);
        }

        [Given(@"the user provides an invalid ""([^""]*)"" and invalid ""([^""]*)""")]
        public void GivenTheUserProvidesAnInvalidAndInvalid(string source, string destination)
        {
            planAJourneyPage.EnterSourceDestination(source, destination);
        }


        [Then(@"the user is taken to the ""([^""]*)"" page")]
        public void ThenTheUserIsTakenToThePage(string expected)
        {
            string title = journeyResultsPage.GetTitle();

            Assert.AreEqual(title, expected);
        }

        [When(@"the user submits the journey")]
        public void WhenTheUserSubmitsTheJourney()
        {
            planAJourneyPage.SubmitJourney();
        }

        [Then(@"an error ""([^""]*)"" is displayed on the page")]
        public void ThenAnErrorIsDisplayedOnThePage(string expected)
        {
            string result = journeyResultsPage.GetErrorText();

            Assert.AreEqual(result, expected);
        }

        [Then(@"a validation error is displayed for the missing source")]
        public void ThenAValidationErrorIsDisplayedForTheMissingSource()
        {
            bool sourceResult = planAJourneyPage.GetSourceError();
            Assert.IsTrue(sourceResult.Equals(true));
        }

        [Then(@"a validation error is displayed for the missing destination")]
        public void ThenAValidationErrorIsDisplayedForTheMissingDestination()
        {
            bool destResult = planAJourneyPage.GetDestError();
            Assert.IsTrue(destResult.Equals(true));
        }

        [Given(@"the user provides an arrival ""([^""]*)""")]
        public void GivenTheUserProvidesAnArrival(string time)
        {
            planAJourneyPage.ChangeTime(time);
        }

        [Then(@"the journey summary is displayed")]
        public void ThenTheJourneySummaryIsDisplayed()
        {
           bool result =  journeyResultsPage.VerifyJourneySummary();

            Assert.IsTrue(result);
        }

        [Then(@"the user can edit the journey")]
        public void ThenTheUserCanEditTheJourney()
        {
            journeyResultsPage.EditJourney();
        }

        [Given(@"the user selects the recent tab")]
        public void GivenTheUserSelectsTheRecentTab()
        {
            planAJourneyPage.SelectRecentJourney();
        }












    }

}
