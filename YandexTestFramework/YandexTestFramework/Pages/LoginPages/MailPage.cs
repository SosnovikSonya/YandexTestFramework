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
    public class MailPage : PageObject
    {
        PageElementsActions pageElementsActions = new PageElementsActions();

        public MailPage(IWebDriver webDriver) : base(webDriver) { }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'user-account_left-name')]")]
        private IWebElement UserLogin { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Выйти')]")]
        private IWebElement LogoutButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'yandex-header__logo-base')]")]
        private IWebElement YandexHeader { get; set; }

        public string GetUserName()
        {
            return pageElementsActions.GetTextFromElement(UserLogin);
        }

        public void ClickOnUserName()
        {
            pageElementsActions.ClickTheButtonWhenIsVisible(UserLogin);
        }

        public void Logout()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(LogoutButton);
        }

        public void YandexHeaderClick()
        {
            pageElementsActions.ClickTheButtonWhenIsVisible(YandexHeader);
        }

    }
}
