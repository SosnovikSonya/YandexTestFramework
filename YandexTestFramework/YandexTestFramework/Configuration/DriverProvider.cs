using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace YandexTestFramework.Configuration
{
    public static class DriverProvider
    {
        public static void InitDriver(BrowserType browser)
        {
            GetDriverInstance(browser);
        }

        public static IWebDriver Driver;

        public static void CleanupDriver()
        {
            Driver.Dispose();
        }

        private static IWebDriver GetDriverInstance(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    return GetFirefoxDriver();
                case BrowserType.IE:
                    return GetIEDriver();
                case BrowserType.Edge:
                    return GetEdgeDriver();
                default:
                    throw new ArgumentException("Unrecognized driver type");
            }
        }

        private static void ConfigureDriver(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(45);
        }

        private static IWebDriver GetChromeDriver()
        {
            //var options = browserOptions.GetChromeOptions();
            Driver = new ChromeDriver();
            ConfigureDriver(Driver);
            return Driver;
        }

        private static IWebDriver GetFirefoxDriver()
        {
            Driver = new FirefoxDriver();
            ConfigureDriver(Driver);
            return Driver;
        }

        private static IWebDriver GetIEDriver()
        {
            throw new NotImplementedException();
        }

        private static IWebDriver GetEdgeDriver()
        {
            throw new NotImplementedException();
        }
    }
}

