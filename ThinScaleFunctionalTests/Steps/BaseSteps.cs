using ThinScaleFunctionalTests.Fixtures;

namespace ThinScaleFunctionalTests.Steps
{
    public abstract class BaseSteps : TechTalk.SpecFlow.Steps
    {
        protected static EnvironmentFixture EnvironmentFixture;

        protected BaseSteps()
        {
            EnvironmentFixture = new EnvironmentFixture();

        }
    }
}
