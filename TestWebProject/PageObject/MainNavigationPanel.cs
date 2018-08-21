using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSelene;
using SeleneTestWebProject.Driver;

namespace SeleneTestWebProject.PageObject
{
    public class MainNavigationPanel : AbstractPage
    {
        public MainNavigationPanel()
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);
            PageFactory.InitElements(seleneDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@role='button']/span[contains(text(),'More')]")]
        public IWebElement MoreButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Trash']")]
        public IWebElement TrashButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Sent Mail')]")]
        public IWebElement SentMailLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Inbox')]")]
        public IWebElement InboxLink { get; set; }
    }
}

