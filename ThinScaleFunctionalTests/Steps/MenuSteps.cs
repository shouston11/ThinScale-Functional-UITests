using ThinScaleFunctionalTests.Pages;
using ThinScaleFunctionalTests.SharedLibrary.Services;
using TechTalk.SpecFlow;

namespace ThinScaleFunctionalTests.Steps
{
    [Binding]
    public sealed class MenuSteps
    {
        private readonly HomePage _homePage;
        private readonly Helper _headerToolbar;

        public MenuSteps(HomePage homePage, Helper headerToolbar)
        {
            _homePage = homePage;
            _headerToolbar = headerToolbar;
        }

        [Given(@"user navigates to the Challenging DOM url")]
        public void GivenUserIsOnHomePage()
        {
            _homePage.GoToChallengingDomPage();
        }

        [Given(@"clicks the edit button on the first line")]
        public void ClickEditButton()
        {
            _headerToolbar.ClickEditButton();
        }

        [Given(@"clicks the delete button on the first line")]
        public void ClickDeleteButton()
        {
            _headerToolbar.ClickDeleteButton();

        }

        [Given(@"clicks the blue button")]
        public void ClickBlueButton()
        {
            _headerToolbar.ClickBlueButton();
        }

        [Given(@"clicks the red alert button")]
        public void ClickRedAlertButton()
        {
            _headerToolbar.ClickRedAlertButton();
        }

        [Given(@"clicks the green success button")]
        public void ClickGreenSuccessButton()
        {
            _headerToolbar.ClickGreenButton();
        }

        [Then(@"the correct page title is returned '(.*)'")]
        public void ThenPageIsReturnedSuccessfully(string page)
        {
            _headerToolbar.ValidateOnCorrectPage(page);
        }

        [Then(@"the correct page header is available '(.*)'")]
        public void CheckPageHeader(string header)
        {
            _headerToolbar.ChallengingDomHeaderIsDisplayed(header);
        }

        [Then(@"the following table headers should be appearing '(.*)'")]
        public void CheckTableHeader(string header)
        {
            _headerToolbar.CheckTableHeaderVisibility(header);
        }

        [Then(@"the url should update after click and contain '(.*)'")]
        public void CheckUrlContainsEdit(string url)
        {
            _headerToolbar.CheckUrlContains(url);
        }
    }
}
