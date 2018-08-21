using NSelene;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleneTestWebProject.Driver;

namespace SeleneTestWebProject.PageObject
{
    public class LogInForm : AbstractPage
    {
        private SeleneDriver _seleneDriver;

        private static readonly By _passwordInputBy = By.CssSelector("input[type = 'password']");
        private static readonly By _loginInputBy = By.CssSelector("input[type ='email']");
        private static readonly By _composeButtonBy = By.XPath("//div[contains(text(),'COMPOSE')]");

        private static readonly By _useAnotherAccountBy = By.XPath("//div[p='Use another account']");
        private static readonly By _logInForm = By.XPath("//*[@id='initialView']/div[contains(@role,'presentation')]");
        private static readonly By _changeUserButton = By.XPath("//*[@id='profileIdentifier']");

        public LogInForm()
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            _seleneDriver = new SeleneDriver(driver);
            PageFactory.InitElements(_seleneDriver, this);
        }

        #region Elements

        [FindsBy(How = How.XPath, Using = "//*[@id='initialView']/div[contains(@role,'presentation')]")]
        public IWebElement LoginForm { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type ='email']")]
        public IWebElement LogInInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement NextEmailButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#passwordNext")]
        public IWebElement NextPasswordButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Switch account']")]
        public IWebElement SwitchAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[p='Use another account']")]
        public IWebElement UseAnotherAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='profileIdentifier']")]
        public IWebElement ChangeUserButton { get; set; }

        #endregion

        public MainEmailBoxPage LogInToEmailBox(string email, string password)
        {
            HomePage homePage = new HomePage();
            IWebDriver driver = Driver.Browser.GetDriver();
            _seleneDriver = new SeleneDriver(driver);

            LogInForm logInForm = new LogInForm();

            _seleneDriver.Find(LoginForm).Should(Be.Visible);

            if (driver.IsElementDisplayed(_changeUserButton))
            {
                ChangeUserButton.Click();
            }
            if (driver.IsElementDisplayed(_useAnotherAccountBy))
            {
                logInForm.UseAnotherAccountButton.Click();
            }

            //Enter credentials 
            _seleneDriver.Find(LogInInput).Should(Be.Visible);

            logInForm.LogInInput.SendKeys(email);
            logInForm.NextEmailButton.Click();

            _seleneDriver.Find(PasswordInput).Should(Be.Visible);

            logInForm.PasswordInput.HighlightElement(_passwordInputBy);
            logInForm.PasswordInput.SendKeys(password);
            logInForm.NextPasswordButton.Click();

            //Wait till main mail box page is loaded 
            MainEmailBoxPage mainEmailBoxPage = new MainEmailBoxPage();

            _seleneDriver.Find(mainEmailBoxPage.ComposeButton).Should(Be.Visible);

            return new MainEmailBoxPage();
        }
    }
}
