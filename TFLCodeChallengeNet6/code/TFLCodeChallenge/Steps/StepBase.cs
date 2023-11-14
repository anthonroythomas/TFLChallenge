using TFLCodeChallengeSpecs.Contexts;

namespace TFLCodeChallengeSpecs.Steps
{
    public abstract class StepBase
    {
        private protected SpecFeatureContext SpecFeatureContext => SpecFeatureContext.Instance;
        private protected SpecScenarioContext SpecScenarioContext => SpecScenarioContext.Instance;
    }
}