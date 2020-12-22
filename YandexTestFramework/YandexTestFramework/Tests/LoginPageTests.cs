using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;
using YandexTestFramework.Pages;
using YandexTestFramework.Pages.LoginPages;
using YandexTestFramework.Utils;

namespace YandexTestFramework.Tests
{
    [AllureNUnit]
    [TestFixture]
    class LoginPageTests : BaseTest
    {
        private LoginPage loginPage;
        private MainPage mainPage;
        private MailPage mailIncomingMessagesPage;

        [SetUp]
        public void SetUp()
        {
            mainPage = new MainPage(WebDriver);
            loginPage = new LoginPage(WebDriver);
            mailIncomingMessagesPage = new MailPage(WebDriver);
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexLogin_ValidCredentials(BrowserType browser)
        {
            mainPage.MailLoginClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            loginPage.EnterLogin(TestData.validLogin);
            loginPage.ClickSignIn();
            loginPage.EnterPassword(TestData.validPassword);
            loginPage.ClickSignIn();

            var userName = mailIncomingMessagesPage.GetUserName();

            Assert.Multiple(() =>
            {
                Assert.NotNull(userName, "User name is null");
                Assert.AreEqual(TestData.validLogin, userName, "User names are not equal");
            });
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexLogout(BrowserType browser)
        {
            mainPage.MailLoginClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            loginPage.EnterLogin(TestData.validLogin);
            loginPage.ClickSignIn();
            loginPage.EnterPassword(TestData.validPassword);
            loginPage.ClickSignIn();

            mailIncomingMessagesPage.ClickOnUserName();

            var loginUrl = windowActions.GetCurrentUrl(WebDriver);
            mailIncomingMessagesPage.Logout();
            var logoutUrl = windowActions.GetCurrentUrl(WebDriver);

            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(loginUrl, logoutUrl, "Url after logout didn't change");
                Assert.IsTrue(loginPage.GetLoginButton().Displayed);
            });

        }

        [TestCase(BrowserType.Chrome)]
        public void YandexLogin_InvalidLogin(BrowserType browser)
        {
            mainPage.MailLoginClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            loginPage.EnterLogin(TestData.invalidLogin);
            loginPage.ClickSignIn();
            Assert.NotNull(loginPage.GetInvalidCredentialText(), "Error message is null");
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexLogin_InvalidPassword(BrowserType browser)
        {
            mainPage.MailLoginClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            loginPage.EnterLogin(TestData.validLogin);
            loginPage.ClickSignIn();
            loginPage.EnterPassword(TestData.invalidPassword);
            loginPage.ClickSignIn();
            Assert.NotNull(loginPage.GetInvalidCredentialText(), "Error message is null");
        }

    }
}
