using TFLCodeChallengeSpecs.Contexts;

namespace TFLCodeChallengeSpecs.Hooks
{
    [Binding]
    public static class TestRunHooks
    {
        [AfterTestRun]
        public static void AfterTestRun()
        {

        }
    }
}
