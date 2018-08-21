using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleneTestWebProject.Driver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IExplorer,         
            RemoteFirefox,
            RemoteChrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            RemoteWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();                     
                        var options = new FirefoxOptions();
                        driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        Browser.GetDriver();
                        break;
                    }
                case BrowserType.RemoteFirefox:
                    {
                        var cability = new FirefoxOptions();
                        
                        //cability.ToCapabilities(CapabilityType.BrowserName, "firefox");
                       // cability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Any));
                        driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), cability);
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("--no-sandbox");
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), option.ToCapabilities());
                        break;
                    }
                case BrowserType.IExplorer:
                    {
                        var service = InternetExplorerDriverService.CreateDefaultService();
                        var option = new InternetExplorerOptions();
                        driver = new InternetExplorerDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
            }
            return driver;
        }
    }
}
