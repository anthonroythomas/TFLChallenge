

namespace TFLCodeChallengeSpecs.Contexts
{
    public class SpecScenarioContext
    {
        private readonly ScenarioContext _scenarioContext;

        public SpecScenarioContext(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        public static SpecScenarioContext Instance { get; set; }

    }
}
