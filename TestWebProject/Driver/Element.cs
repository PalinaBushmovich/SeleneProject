using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using TestWebProject.Driver.Interfaces;


namespace TestWebProject.Driver
{
    public class element : IElement
    {
        protected string name;
        protected By locator;
        protected IWebElement webElement;
        protected IWebDriver driver;

        public string TagName => webElement.TagName;

        public string Text => webElement.Text;

        bool IWebElement.Enabled => webElement.Enabled;

        bool IWebElement.Selected => webElement.Selected;

        Point IWebElement.Location => webElement.Location;

        Size IWebElement.Size => webElement.Size;

        bool IWebElement.Displayed => webElement.Displayed;

        public element(By locator,string name)
        {
            this.locator = locator;
            this.name =name == "" ? this.GetText() :name;
        }

        public element(By locator)
        {
            this.locator = locator;

        }

        public element()
        {
        }

        public IWebElement GetElement()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);

            return this.webElement;
        }

        public string GetText()
        {
            this.WaitForIsVisible();
            return this. webElement.Text;
        }

        public bool WaitForIsVisible(int timeOutInSeconds = 5)
        {
            return this. webElement.Displayed;

        }

        public void Click()
        {
            try
            {
                this.webElement = Browser.GetDriver().FindElement(this.locator);
                this.webElement.Click();
            }
            catch
            {
                Console.WriteLine($"Element '{webElement}' is not displayed");

            }
        }

        public void SendKeys(string text)
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            this.webElement.SendKeys(text);
        }

        public bool Enabled()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            return this. webElement.Enabled;
        }

        public bool Selected()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            return webElement.Selected;
        }

        public bool Displayed()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            return this.webElement.Displayed;
        }


        public Point Location()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
           return this.webElement.Location;
        }

        public Size Size()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            return this.webElement.Size;
        }

        public void Submit()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            this.webElement.Submit();

        }

        public string GetCssValue(string propertyName)
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
           string cssValue = this. webElement.GetCssValue(propertyName);
            return cssValue;
        }

        public List<IWebElement> FindElements(By locator, int waitTimeInSeconds = 20)
        {
            var currentElement = driver.WaitForElementExist(locator, waitTimeInSeconds);
            var elements = webElement.FindElements(locator);
            return new List<IWebElement>(elements);
        }

        public void Clear()
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            this. webElement.Clear();
        }

        public string GetAttribute(string attributeName)
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);
            return this. webElement.GetAttribute(attributeName);

        }

        IWebElement ISearchContext.FindElement(By by)
        {
            throw new NotImplementedException();
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void IsElementVisible( int timeoutSecs = 10)
        {
            this.webElement = Browser.GetDriver().FindElement(this.locator);

            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(timeoutSecs)).Until(ExpectedConditions.ElementIsVisible(this.locator));
        }

        public bool IsDisplayed()
        {
            IsElementVisible();
            var elementOnPage = Browser.GetDriver().FindElement(this.locator);
            if (elementOnPage.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
