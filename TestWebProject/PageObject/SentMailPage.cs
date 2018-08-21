using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using SeleneTestWebProject.Driver;
using NSelene;

namespace SeleneTestWebProject.PageObject
{
    public class SentMailPage : AbstractPage
    {
        public SentMailPage()
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);
            PageFactory.InitElements(seleneDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@name = 'dxvcdescfsdc']/../..")]
        public IWebElement RecipientName { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@name = 'Eduard Tumas']/../..")]
        public IWebElement SenderName { get; set; }

    }
}
