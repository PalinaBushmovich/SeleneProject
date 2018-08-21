using OpenQA.Selenium;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace SeleneTestWebProject.Driver
{
    public class Browser
    {
        private static Browser _currentInstance;
        private static IWebDriver _driver;
        public static BrowserFactory.BrowserType CurrentBrowser;
        public static int ImplWait = 20;
        public static double TimeoutForElement;
        private static string _browser;

        private Browser()
        {
            InitParamas();
            _driver = BrowserFactory.GetDriver(CurrentBrowser, ImplWait);
        }

        private static void InitParamas()
        {
            ImplWait = Convert.ToInt32(Configurations.PageTimeout);
            TimeoutForElement = Convert.ToDouble(Configurations.ElementTimeout);
            _browser = Configurations.Browser;
            Enum.TryParse(_browser, out CurrentBrowser);
        }

        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());

        public static void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void Quit()
        {
            _driver.Quit();
            _currentInstance = null;
            _driver = null;
            _browser = null;
            var driverProcess = Process.GetProcessesByName("chromedriver.exe");
            foreach (var process in driverProcess)
            {
                process.Kill();
            }
        }

    }
}
