using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;
using YandexTestFramework.Pages;
using YandexTestFramework.Pages.LoginPages;
using YandexTestFramework.Utils;
using YandexTestFramework.Utils.Actions;

namespace YandexTestFramework.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver WebDriver { get; private set; }
        protected MainPage MainPage;
        protected LoginPage LoginPage;
        protected WindowActions windowActions;

        [SetUp]
        public void BaseTestSetUp()
        {
            BrowserType browser;
            Enum.TryParse(TestContext.CurrentContext.Test.Arguments[0].ToString(), out browser);
            DriverProvider.InitDriver(browser);
            WebDriver = DriverProvider.Driver;
            WebDriver.Navigate().GoToUrl(TestData.baseUrl);
            windowActions = new WindowActions();
        }

        [OneTimeSetUp]
        public static void BeforeTestRun()
        {
            //Set default working directory for NUnit to store allure results
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [TearDown]
        public void BaseTearDown()
        {
            DriverProvider.CleanupDriver();
        }
    }
}
