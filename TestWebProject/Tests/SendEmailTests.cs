using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleneTestWebProject.Driver;
using SeleneTestWebProject.PageObject;

namespace TestWebProject
{
    [TestClass]
    public class SendEmailTests : BaseTest
    {
        private MainNavigationPanel _navigationPanel;
        private MainEmailBoxPage _mainEmailBoxPage;
        private SentMailPage _sentMailPage;
        private LogInForm _logInform;
        private HomePage _homePage;
        TrashPage _trashPage;

        [ClassInitialize()]
        public static void SendEmailTestsInitialize(TestContext context)
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }

        [TestMethod, TestCategory("Email")]
        public void LogInSendEmailLogOut_LogInChechThatEmailIsSent()
        {
           // IHomePage _homePage = new HomePageDecorator(new HomePage());

            _logInform = _homePage.OpenLoginForm();

            //Log in as first user
            _logInform.LogInToEmailBox(Constants.Sender, Constants.Password);

            //Verify that login is successful
            _navigationPanel = new MainNavigationPanel();

            bool isFirstLoginSuccessfull = _navigationPanel.IsElementVisible(_navigationPanel.InboxLink);
            Assert.IsTrue(isFirstLoginSuccessfull, $"Login of first user '{Constants.Sender}' was not successful");

            //Write and send an email
            _mainEmailBoxPage.SendEmail(Constants.Recipient, Constants.Message);

            //Verify that email is in sent mail box 
            _navigationPanel.SentMailLink.Click();

            _sentMailPage = new SentMailPage();

            bool isEmailInSentBox = _sentMailPage.IsElementVisible(_sentMailPage.RecipientName);
            Assert.IsTrue(isEmailInSentBox, "Email was not sent and is not resent in Sent Mail box");

            _logInform = _mainEmailBoxPage.SignOut();

            _logInform.LogInToEmailBox(Constants.Recipient, Constants.Password);

            //Verify that login is successful
            bool isSecondLoginSuccessfull = _navigationPanel.InboxLink.Displayed;
           Assert.IsTrue(isSecondLoginSuccessfull, $"Login of second user '{Constants.Recipient}' was not successful");

            //Verify that email is in Inbox 
            bool isEmailInInbox = _sentMailPage.IsElementVisible(_sentMailPage.SenderName);
            Assert.IsTrue(isEmailInInbox, $"Email is not displayed in Inbox");

            //Drag&drop email to trash
            _mainEmailBoxPage.DeleteEmail(Constants.SenderName);

            //Verify that email is in the trash
            _navigationPanel.TrashButton.Click();

            _trashPage = new TrashPage();

            bool isEmailInTrash = _trashPage.IsElementVisible(_trashPage.SenderName);
            Assert.IsTrue(isEmailInInbox, $"Email is not displayed in Trash");
        }
    }
}
