using NUnit.Framework;
using System.Xml.Linq;
using PnP.Framework.Modernization.Transform;
using Microsoft.SharePoint.News.DataModel;
using TechTalk.SpecFlow.Assist;
using TFLCodeChallengeSpecs.Contexts;
using TFLCodeChallengeSpecs.Pages;
using TFLCodeChallengeSpecs.Config;

namespace TFLCodeChallengeSpecs.Steps
{
    [Binding]
    public class sharedSteps : StepBase

    {
        private DriverHelper _driverHelper;

        PlanAJourneyPage planAJourneyPage;

        //  Environment-specific settings
        private readonly Env _env;

        private readonly string journeyPlannerURL;

        public sharedSteps(Env env, DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

            planAJourneyPage = new PlanAJourneyPage(_driverHelper.Driver);

            _env = env;

            journeyPlannerURL = env.JourneyPlannerURL;
        }

        [Given(@"the user accepts the cookie prompt")]
        public void GivenTheUserAcceptsTheCookiePrompt()
        {
            planAJourneyPage.AcceptCookies();
        }

    }

}
