using OpenQA.Selenium.Chrome;
using TFLCodeChallengeSpecs.Contexts;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TFLCodeChallengeSpecs.Hooks
{
    [Binding]
    public sealed class ScenarioHooks
    {
        private DriverHelper _driverHelper;
        public ScenarioHooks(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Before Scenario: ChromeDriver Setup");
            ChromeOptions option = new ChromeOptions();
            //option.AddArguments("--headless=new");
            option.AddArguments("--window-size=1920,1080");
            option.AddArguments("--disable-gpu");
            option.AddArguments("--disable-extensions");
            option.AddArgument("--ignore-certificate-errors");
            option.AddArgument("--allow-insecure-localhost");

            Console.WriteLine("Before Scenario: WebDriver Setup");
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            Console.WriteLine("Setup Driver");
            _driverHelper.Driver = new ChromeDriver(option);
            _driverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Console.WriteLine("Before Scenario: Finished");

            SpecScenarioContext.Instance = new SpecScenarioContext(scenarioContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }
    }
}
