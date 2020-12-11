using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Utils;
using YandexTestFramework.Utils.Actions;

namespace YandexTestFramework.Pages.TabNavigationPages
{
    public class YandexMusicPage : PageObject
    {
        public YandexMusicPage(IWebDriver webDriver) : base(webDriver) { }
        PageElementsActions pageElementsActions = new PageElementsActions();

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'deco-input_suggest')]")]
        private IWebElement SearchInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'payment-plus__header-close')]")]
        private IWebElement AdvertisementClose { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'd-suggest__item-artist')]//*[text()='" + TestData.artist + "']/../..")]
        private IWebElement SearchResult { get; set; }
        [FindsBy(How = How.XPath, Using = "//h1[contains(@class, 'page-artist__title')]")]
        private IWebElement ArtistTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'album__artist')]")]
        private IList<IWebElement> PopularAlbumsArtist { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'd-suggest__item-artist')]//*[text()='" + TestData.artistForPlaying + "']/../..")]
        private IWebElement SearchResultForPlaying { get; set; }

        public void EnterSearchInput(string text)
        {
            pageElementsActions.InputDataInTheField(SearchInput, text);
        }

        public void AdvertisementCloseClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(AdvertisementClose);
        }

        public void SearchResultClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(SearchResult);
        }

        public string GetArtistTitle()
        {
            return pageElementsActions.GetTextFromElement(ArtistTitle);
        }

        public IList<IWebElement> GetPopularAlbumsArtist()
        {
            return pageElementsActions.GetWebElements(PopularAlbumsArtist);
        }

        public void SearchResultForPlayingClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(SearchResultForPlaying);
        }
    }
}
