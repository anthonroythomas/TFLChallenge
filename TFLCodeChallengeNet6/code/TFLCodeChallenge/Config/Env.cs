using System.Text;

namespace TFLCodeChallengeSpecs.Config
{
    public class Env
    {
        public Env() { }

        public string JourneyPlannerURL { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("JourneyPlannerURL").Append(JourneyPlannerURL).Append("\n");
            sb.Append("Name").Append(Name).Append("\n");
            return sb.ToString();
        }
    }
}
