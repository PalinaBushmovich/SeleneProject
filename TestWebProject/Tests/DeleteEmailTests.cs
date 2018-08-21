using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleneTestWebProject.Driver;
using SeleneTestWebProject.PageObject;

namespace TestWebProject.Tests
{
    [TestClass]
    public class DeleteEmailTests : BaseTest
    {
        private HomePage _homePage;
        private MainNavigationPanel _navigationPanel;
        private MainEmailBoxPage _mainEmailBoxPage;
        private SentMailPage _sentMailPage;
        private LogInForm _logInform;

        [ClassInitialize()]
        public static void SendEmailTestsInitialize(TestContext context)
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        [TestMethod, TestCategory("Email")]
        public void LogInSendEmail_DeleteViaRightMouseClick()
        {
            _homePage = new HomePage();

            _logInform = _homePage.OpenLoginForm();

            //Log in as first user
            _mainEmailBoxPage = _logInform.LogInToEmailBox(Constants.Sender, Constants.Password);

            _navigationPanel = new MainNavigationPanel();

            //Verify that login is successful

            bool isFirstLoginSuccessfull = _navigationPanel.IsElementVisible(_navigationPanel.InboxLink);
            Assert.IsTrue(isFirstLoginSuccessfull, $"Login of first user '{Constants.Sender}' was not successful");

            //Write and send an email
            _mainEmailBoxPage.SendEmail(Constants.Recipient, Constants.Message);

            _logInform = _mainEmailBoxPage.SignOut();

            _logInform.LogInToEmailBox(Constants.Recipient, Constants.Password);

            //Delete an email
            _mainEmailBoxPage.DeleteEmailViaRightClick(Constants.SenderName);

        }
    }
}
