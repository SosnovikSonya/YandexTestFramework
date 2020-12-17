using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;
using YandexTestFramework.Pages;
using YandexTestFramework.Pages.SettingsPages;
using YandexTestFramework.Pages.TabNavigationPages;
using YandexTestFramework.Utils;

namespace YandexTestFramework.Tests
{
    [TestFixture]
    class MainPageTests : BaseTest
    {
        private MainPage mainPage;
        private YandexVideoPage yandexVideoPage;
        private YandexPicturesPage yandexPicturesPage;
        private YandexNewsPage yandexNewsPage;
        private YandexMarketPage yandexMarketPage;
        private YandexTranslatorPage yandexTranslatorPage;
        private YandexMusicPage yandexMusicPage;
        private GeoPositionSettingsPage geoPositionSettingsPage;
        private LanguageSettingsPage languageSettingsPage;

        [SetUp]
        public void SetUp()
        {
            mainPage = new MainPage(WebDriver);
            yandexVideoPage = new YandexVideoPage(WebDriver);
            yandexPicturesPage = new YandexPicturesPage(WebDriver);
            yandexNewsPage = new YandexNewsPage(WebDriver);
            yandexMarketPage = new YandexMarketPage(WebDriver);
            yandexTranslatorPage = new YandexTranslatorPage(WebDriver);
            yandexMusicPage = new YandexMusicPage(WebDriver);
            geoPositionSettingsPage = new GeoPositionSettingsPage(WebDriver);
            languageSettingsPage = new LanguageSettingsPage(WebDriver);
        }


        [TestCase(BrowserType.Chrome)]
        public void YandexNavigation_VideoTab(BrowserType browser)
        {
            mainPage.TabVideoClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(windowActions.GetCurrentUrl(WebDriver).Contains("video"), "Url doesn't contain word 'video'");
                Assert.IsTrue(yandexVideoPage.GetTabVideo().GetAttribute("aria-disabled").Contains("true"), "Tab video isn't disable");
            });
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexNavigation_PicturesTab(BrowserType browser)
        {
            mainPage.TabPicturesClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(windowActions.GetCurrentUrl(WebDriver).Contains("images"), "Url doesn't contain word 'images'");
                Assert.IsTrue(yandexPicturesPage.GetTabPictures().GetAttribute("aria-disabled").Contains("true"), "Tab video isn't disable");
            });
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexNavigation_NewsTab(BrowserType browser)
        {
            mainPage.TabNewsClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(windowActions.GetCurrentUrl(WebDriver).Contains("news"), "Url doesn't contain word 'news'");
                Assert.IsTrue(yandexNewsPage.GetTabNews().GetAttribute("class").Contains("navigation__item_state_selected"), "Tab video isn't selected");
            });
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexNavigation_MarketTab(BrowserType browser)
        {
            mainPage.TabMarketClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(windowActions.GetCurrentUrl(WebDriver).Contains("market"), "Url doesn't contain word 'market'");
                Assert.IsTrue(yandexMarketPage.GetLogoMarket().Displayed, "Logo of market isn't displayed");
            });
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexNavigation_TranslatorTab(BrowserType browser)
        {
            mainPage.TabTranslatorClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(windowActions.GetCurrentUrl(WebDriver).Contains("translate"), "Url doesn't contain word 'translate'");
                Assert.IsTrue(yandexTranslatorPage.GetLogoTranslator().Displayed, "Logo of translator isn't displayed");
            });
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexNavigation_MusicTab(BrowserType browser)
        {
            mainPage.TabMusicClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);

            Assert.IsTrue(windowActions.GetCurrentUrl(WebDriver).Contains("music"), "Url doesn't contain word 'music'");
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexLanguageChange(BrowserType browser)
        {
            mainPage.CurrentLanguageClick();
            mainPage.LanguageMoreClick();
            languageSettingsPage.LanguageDropDownButtonClick();
            languageSettingsPage.LanguageToChangeClick();
            languageSettingsPage.SaveButtonClick();
            Assert.AreEqual(TestData.CurrentLanguageAbbreviation, mainPage.GetCurrentLanguageText(), "Current language abbreviation isn't equal to actual language");
        }

        [TestCase(BrowserType.Chrome)]
        public void CompareTabMoreContent(BrowserType browser)
        {
            mainPage.GeoPositionClick();
            geoPositionSettingsPage.ChangeCity(TestData.City);
            mainPage.TabMoreClick();

            var firstCityMoreTabContent = mainPage.GetMoreTabContent();

            var firstCityContentText = firstCityMoreTabContent.Select(a => a.Text).ToList();

            mainPage.GeoPositionClick();
            geoPositionSettingsPage.ChangeCity(TestData.CityToChange);
            mainPage.TabMoreClick();

            var secondCityMoreTabContent = mainPage.GetMoreTabContent();

            var secondCityContentText = secondCityMoreTabContent.Select(a => a.Text).ToList();

            Assert.AreEqual(firstCityContentText, secondCityContentText, "Content of two tabs are not equal in  different geo position");
        }
    }
}
