using NSelene;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using SeleneTestWebProject.Driver;

namespace SeleneTestWebProject.PageObject
{
    public class EmailContentPage : AbstractPage
    {
        public EmailContentPage()
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);
            PageFactory.InitElements(seleneDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[data-tooltip='Delete']")]
        public IWebElement DeleteButton { get; set; }
    }
}
