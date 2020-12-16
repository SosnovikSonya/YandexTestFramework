using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;
using YandexTestFramework.Pages.LoginPages;
using YandexTestFramework.Pages.SettingsPages;
using YandexTestFramework.Pages.TabNavigationPages;
using YandexTestFramework.Utils;
using YandexTestFramework.Utils.Actions;

namespace YandexTestFramework.Pages
{
    public class MainPage : PageObject
    {
        PageElementsActions pageElementsActions = new PageElementsActions();

        public MainPage(IWebDriver webDriver) : base(webDriver) { }

        [FindsBy(How = How.XPath, Using = "//span[text()='Войти в почту']/..")]
        private IWebElement LoginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-id='video']")]
        private IWebElement TabVideo { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-id='images']")]
        private IWebElement TabPictures { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-id='news']")]
        private IWebElement TabNews { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-id='maps']")]
        private IWebElement TabMaps { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-id='market']")]
        private IWebElement TabMarket { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-id='translate']")]
        private IWebElement TabTranslator { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-id='music']")]
        private IWebElement TabMusic { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-id='more']")]
        private IWebElement TabMore { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'services-new__more-popup-item') and not(contains(@style, 'display: none;'))]")]
        private IList<IWebElement> TabMoreContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'b-langs')]")]
        private IWebElement CurrentLanguage { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@data-statlog='head.lang.more']")]
        private IWebElement LanguageMore { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'home-link geolink')]")]
        private IWebElement GeoPosition { get; set; }

        public LoginPage MailLoginClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(LoginButton);
            return new LoginPage(WebDriver);
        }

        public YandexVideoPage TabVideoClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(TabVideo);
            return new YandexVideoPage(WebDriver);
        }

        public YandexPicturesPage TabPicturesClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(TabPictures);
            return new YandexPicturesPage(WebDriver);
        }

        public YandexNewsPage TabNewsClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(TabNews);
            return new YandexNewsPage(WebDriver);
        }

        public YandexMarketPage TabMarketClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(TabMarket);
            return new YandexMarketPage(WebDriver);
        }

        public YandexTranslatorPage TabTranslatorClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(TabTranslator);
            return new YandexTranslatorPage(WebDriver);
        }

        public YandexMusicPage TabMusicClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(TabMusic);
            return new YandexMusicPage(WebDriver);
        }

        public void TabMoreClick()
        {
            var element = WebDriver.FindElement(By.XPath("//*[@data-id='more']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)DriverProvider.Driver;
            executor.ExecuteScript("arguments[0].click();", pageElementsActions.GetWebElement(element));
            //pageElementsActions.ClickTheButtonWhenIsClickable(TabMore);
        }

        public IList<IWebElement> GetMoreTabContent()
        {
            return pageElementsActions.FindElementsBy(By.XPath("//*[contains(@class, 'services-new__more-popup-item') and not(contains(@style, 'display: none;'))]"));
            //return pageElementsActions.GetWebElements(elements);
        }

        public void CurrentLanguageClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(CurrentLanguage);
        }

        public string GetCurrentLanguageText()
        {
            return pageElementsActions.GetTextFromElement(CurrentLanguage);
        }

        public LanguageSettingsPage LanguageMoreClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(LanguageMore);
            return new LanguageSettingsPage(WebDriver);
        }

        public GeoPositionSettingsPage GeoPositionClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(GeoPosition);
            return new GeoPositionSettingsPage(WebDriver);
        }
    }
}
