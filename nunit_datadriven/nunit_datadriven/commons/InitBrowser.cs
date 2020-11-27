using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace nunit_datadriven.commons
{
    public class InitBrowser
    {
        private static IWebDriver driver;

        // public ReadEnv env;
        public string browser = null;

        public InitBrowser()
        {
            //  env = new ReadEnv();
            //  browser = env.GetProperty("base", "browser");
        }

        public static IWebDriver Getbrowser()
        {
            string browser = ReadEnv.ReadData("base", "browser");
            if (browser.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            {
                if (driver == null)
                {
                    var chromeOptions = new ChromeOptions();
                    // chromeOptions.BrowserVersion = "67";
                    // chromeOptions.PlatformName = "Windows 10";
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);

                    return driver;
                }
                else
                    return driver;
            }

            if (browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
            {
                if (driver == null)
                {
                    driver = new FirefoxDriver();

                    return driver;
                }
                else
                    return driver;
            }

            return driver;
        }
    }
}