using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Utils;
using YandexTestFramework.Utils.Actions;

namespace YandexTestFramework.Pages.LoginPages
{
    public class LoginPage : PageObject
    {
        PageElementsActions pageElementsActions = new PageElementsActions();

        public LoginPage(IWebDriver webDriver) : base(webDriver) { }

        [FindsBy(How = How.XPath, Using = "//*[@id='passp-field-login']")]
        private IWebElement Login { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='passp-field-passwd']")]
        private IWebElement Password { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[text()='Войти']/..")]
        private IWebElement LoginButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='Textinput-Hint Textinput-Hint_state_error']")]
        private IWebElement InvalidCredential { get; set; }

        public void EnterLogin(string login)
        {
            pageElementsActions.InputDataInTheField(Login, login);
        }

        public void EnterPassword(string password)
        {
            pageElementsActions.InputDataInTheField(Password, password);
        }

        public void ClickSignIn()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(LoginButton);
        }

        public string GetInvalidCredentialText()
        {
            return pageElementsActions.GetTextFromElement(InvalidCredential);
        }

        public IWebElement GetLoginButton()
        {
            return pageElementsActions.GetWebElement(LoginButton);
        }

        public void SignIn(string login, string password)
        {
            pageElementsActions.InputDataInTheField(Login, login);
            pageElementsActions.ClickTheButtonWhenIsClickable(LoginButton);
            pageElementsActions.InputDataInTheField(Password, password);
            pageElementsActions.ClickTheButtonWhenIsClickable(LoginButton);
        }
    }
}
