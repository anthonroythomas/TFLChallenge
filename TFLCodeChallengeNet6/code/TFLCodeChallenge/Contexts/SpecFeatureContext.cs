using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLCodeChallengeSpecs.Contexts
{
    public class SpecFeatureContext
    {
        private readonly FeatureContext _featureContext;

        public SpecFeatureContext(FeatureContext featureContext)
        {
            _featureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));
        }

        public static SpecFeatureContext Instance { get; set; }
    }
}
