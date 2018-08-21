using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleneTestWebProject.Driver;
using NSelene;

namespace SeleneTestWebProject.PageObject
{
    public class EmailForm : AbstractPage
    {

        public EmailForm()
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);
            PageFactory.InitElements(seleneDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//td/form")]
        public IWebElement SendForm { get; set; }

        [FindsBy(How = How.XPath, Using = "//td/form//textarea[@name='to']")]
        public IWebElement ToField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        public IWebElement MessageArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Send')]")]
        public IWebElement SendButton { get; set; }

        [FindsBy(How = How.XPath, Using = " //input[contains(@name,'subjectbox')]")]
        public IWebElement SubjectInput { get; set; }

       
    }
}
