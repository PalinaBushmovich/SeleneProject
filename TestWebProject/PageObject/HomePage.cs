using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSelene;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleneTestWebProject.PageObject
{
    public class HomePage
    {

        public HomePage()
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);
            PageFactory.InitElements(seleneDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign In']")]
        public IWebElement SignInButton { get; set; }

        public LogInForm OpenLoginForm()
        {
            SignInButton.Click();
            return new LogInForm();
        }
    }
}
