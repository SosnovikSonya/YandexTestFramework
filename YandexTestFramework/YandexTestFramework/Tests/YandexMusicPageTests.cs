using NUnit.Allure.Core;
using NUnit.Framework;
using YandexTestFramework.Configuration;
using YandexTestFramework.Pages;
using YandexTestFramework.Pages.LoginPages;
using YandexTestFramework.Pages.TabNavigationPages;
using YandexTestFramework.Utils;

namespace YandexTestFramework.Tests
{
    [AllureNUnit]
    [TestFixture]
    public class YandexMusicPageTests : BaseTest
    {
        private MainPage mainPage;
        private YandexMusicPage yandexMusicPage;
        private LoginPage loginPage;
        private MailPage mailIncomingMessagesPage;

        [SetUp]
        public void SetUp()
        {
            mainPage = new MainPage(WebDriver);
            yandexMusicPage = new YandexMusicPage(WebDriver);
            loginPage = new LoginPage(WebDriver);
            mailIncomingMessagesPage = new MailPage(WebDriver);

            mainPage.MailLoginClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
            loginPage.SignIn(TestData.validLogin, TestData.validPassword);
            mailIncomingMessagesPage.YandexHeaderClick();
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexMusic_SearchMusic(BrowserType browser)
        {
            mainPage.TabMusicClick();
            windowActions.SwitchBetweenWindows(WebDriver, 2);
            yandexMusicPage.AdvertisementCloseClick();
            yandexMusicPage.EnterSearchInput(TestData.searchInMusic);
            yandexMusicPage.SearchResultClick();
            var artist = yandexMusicPage.GetArtistTitle();
            Assert.AreEqual(TestData.artist, artist, "Actual and expected artists are not equal");

            var popularAlbums = yandexMusicPage.GetPopularAlbumsArtist();
            foreach (var album in popularAlbums)
            {
                Assert.AreEqual(TestData.artist, album.Text, "Actual and expected artists in popular albums are not equal");
            }
        }
    }
}
