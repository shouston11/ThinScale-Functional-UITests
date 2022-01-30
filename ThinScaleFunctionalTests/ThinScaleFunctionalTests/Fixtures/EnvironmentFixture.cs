using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using ThinScaleFunctionalTests.Models.Environment;
using Environment = ThinScaleFunctionalTests.Models.Environment.Environment;

namespace ThinScaleFunctionalTests.Fixtures
{
    public class EnvironmentFixture
    {
        public EnvironmentFixture()
        {
            System.Environment.SetEnvironmentVariable("EnvironmentName", "ThinScale");
            var environmentName = System.Environment.GetEnvironmentVariable(Constants.EnvironmentName);
            Environment = GetEnvironment(environmentName);
        }

        public Environment Environment { get; set; }

        private Environment GetEnvironment(string environmentName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("ThinScaleFunctionalTests.Data.EnvironmentData.json");
            using var reader = new StreamReader(stream);
            var read = reader.ReadToEnd();
            var readJson = JsonConvert.DeserializeObject<EnvironmentModel>(read);

            var environment = readJson.Environments.First(x =>
                x.Name.Equals(environmentName, StringComparison.InvariantCultureIgnoreCase));
            if (environment == null)
            {
                var message = $"Could not find configuration for Environment:{environmentName}." +
                              " \nPlease check the EnvironmentData.Json file in the solution to select a valid environment." +
                              " \nPlease set a valid environment in the environment data json.";
                // var exception = new CouldNotFindValidEnvironmentConfigurationException(message);
                //throw exception;
            }

            environment.Name = environmentName;
            return environment;
        }
    }
}
