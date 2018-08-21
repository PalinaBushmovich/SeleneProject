using OpenQA.Selenium;
using NSelene;

namespace SeleneTestWebProject.PageObject
{
    public abstract class AbstractPage
    {          
        public void HighlightElement(By locator)
        {
            IWebDriver driver = Driver. Browser.GetDriver();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement askQuestionElement = driver.FindElement(locator);
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", askQuestionElement);
        }     
        
        public bool IsElementVisible(IWebElement element)
        {
            IWebDriver driver = Driver.Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);

            seleneDriver.Find(element).Should(Be.Visible);

            return element.Displayed;
        }

    }
}
