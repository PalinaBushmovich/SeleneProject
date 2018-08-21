using NSelene;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleneTestWebProject.Driver
{
    public static class WebDriverExtensions
    {
        public static WebDriverWait Wait(this IWebDriver Driver, int waitTimeoutSeconds = 6, int iterationDelaySeconds = 2)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeoutSeconds));
            wait.PollingInterval = TimeSpan.FromSeconds(iterationDelaySeconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(NullReferenceException), typeof(WebDriverException), typeof(WebDriverTimeoutException));

            return wait;
        }

        public static void HighlightElement(this IWebElement element, By by)
        {
            IWebDriver driver = Browser.GetDriver();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement askQuestionElement = driver.FindElement(by);
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", askQuestionElement);
        }

        public static void JSclick(this IWebElement element, By locator)
        {
            IWebDriver driver = Browser.GetDriver();
            SeleneDriver seleneDriver = new SeleneDriver(driver);
            seleneDriver.Find(locator).Should(Be.Visible);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(locator));

        }

        public static bool IsElementDisplayed(this IWebDriver Driver, By by, int timeoutInSeconds = 5)
        {
            // Wait for element to be displayed
            try
            {
                Wait(Driver, timeoutInSeconds).Until(d => d.FindElements(by).Count > 0 && d.FindElement(by).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
