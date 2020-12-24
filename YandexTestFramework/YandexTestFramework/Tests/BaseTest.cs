using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using YandexTestFramework.Configuration;
using YandexTestFramework.Pages;
using YandexTestFramework.Pages.LoginPages;
using YandexTestFramework.Utils;
using YandexTestFramework.Utils.Actions;
using NUnit.Framework.Interfaces;
using Allure.Commons;

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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureResultsUtils.TakeScreenShot(TestContext.CurrentContext.Test.Name);
                AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", $"{TestContext.CurrentContext.Test.Name}_screenshot.png");
            }

            DriverProvider.CleanupDriver();
        }
    }
}
