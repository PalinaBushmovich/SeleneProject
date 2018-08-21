using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleneTestWebProject.Driver
{
    public class Configurations
    {
        public static string GetEnvinromentVar (string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvinromentVar("ElementTimeout", "30");

        public static string PageTimeout => GetEnvinromentVar("PageTimeout", "10");

        public static string Browser => GetEnvinromentVar("BrowserType", "Chrome");

        public static string StartUrl => GetEnvinromentVar("StartUrl", "https://www.google.com/intl/en/gmail/about/#");
    }
}
