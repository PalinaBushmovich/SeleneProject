using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleneTestWebProject.Driver;
using NSelene;

namespace SeleneTestWebProject.PageObject
{
    public class TrashPage : AbstractPage
    {
        public TrashPage()
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);
            PageFactory.InitElements(seleneDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@name = 'Eduard Tumas']/../..")]
        public IWebElement SenderName { get; set; }
    }
}
