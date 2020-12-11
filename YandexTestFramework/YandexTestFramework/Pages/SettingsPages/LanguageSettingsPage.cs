using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Utils;
using YandexTestFramework.Utils.Actions;

namespace YandexTestFramework.Pages.SettingsPages
{
    public class LanguageSettingsPage : PageObject
    {
        public LanguageSettingsPage(IWebDriver webDriver) : base(webDriver) { }

        PageElementsActions pageElementsActions = new PageElementsActions();

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'select__button')]")]
        private IWebElement LanguageDropDownButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[text()='" + TestData.languageToChange + "']/..")]
        private IWebElement LanguageToChange { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'form__save')]")]
        private IWebElement SaveButton { get; set; }

        public void LanguageDropDownButtonClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(LanguageDropDownButton);
        }

        public void LanguageToChangeClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(LanguageToChange);
        }

        public MainPage SaveButtonClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(SaveButton);
            return new MainPage(WebDriver);
        }
    }
}
