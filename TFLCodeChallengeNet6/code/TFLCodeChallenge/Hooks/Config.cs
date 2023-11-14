using BoDi;
using Microsoft.Extensions.Configuration;
using System.Text;
using TFLCodeChallengeSpecs.Config;

namespace TFLCodeChallengeSpecs.Hooks
{
    [Binding]
    public class ConfigProvider
    {
        private static Env _env;

        [BeforeTestRun]
        public static void LoadEnvironmentConfiguration()
        {
            if (_env != null) return;

            var name = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            var sb = new StringBuilder("appsettings");
            if (name != null)
                sb.Append(".").Append(name.ToLower());
            sb.Append(".json");
            var configFile = sb.ToString();

            var configuration = new ConfigurationBuilder()
                        .AddJsonFile(configFile, false, false)
                        .Build();
            if (configuration != null)
            {
                var section = configuration.GetSection("Environment");
                if (section != null)
                    _env = section.Get<Env>();
            }
            if (_env == null)
                _env = new Env();

            _env.Name = name ?? "local";

            Console.WriteLine("Loaded environment from " + configFile);
            Console.WriteLine(_env.ToString());

        }

        [BeforeScenario]
        public void GetEnvironmentConfiguration(IObjectContainer container)
        {
            container.RegisterInstanceAs(_env);
        }
    }
}
