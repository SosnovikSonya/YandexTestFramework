using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;
using YandexTestFramework.Pages;
using YandexTestFramework.Pages.TabNavigationPages;
using YandexTestFramework.Utils;

namespace YandexTestFramework.Tests
{
    [AllureNUnit]
    [TestFixture]
    public class YandexMarketPageTests : BaseTest
    {
        private MainPage mainPage;
        private YandexMarketPage yandexMarketPage;

        [SetUp]
        public void SetUp()
        {
            mainPage = new MainPage(WebDriver);
            yandexMarketPage = new YandexMarketPage(WebDriver);
            mainPage.TabMarketClick();
            windowActions.SwitchBetweenWindows(WebDriver, 1);
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexMarket_AddToComparison(BrowserType browser)
        {
            yandexMarketPage.EnterSearchText(TestData.searchInMarket);
            yandexMarketPage.SearchButtonClick();

            var addButtons = yandexMarketPage.GetAddToComparisonButtons();
            yandexMarketPage.AddToComparison(addButtons[0]);
            yandexMarketPage.AddToComparison(addButtons[1]);

            yandexMarketPage.CompareButtonClick();

            var items = yandexMarketPage.GetItemsInComparisonList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, items.Count, "Assert there are two item in the list to compare");
                Assert.IsTrue(items.ElementAt(0).Text.Contains(TestData.searchInMarket), "Assert first item's text contains search text");
                Assert.IsTrue(items.ElementAt(1).Text.Contains(TestData.searchInMarket), "Assert second item's text contains search text");
            });
        }

        [TestCase(BrowserType.Chrome)]
        public void YandexMarket_DeleteFromComparison(BrowserType browser)
        {
            yandexMarketPage.EnterSearchText(TestData.searchInMarket);
            yandexMarketPage.SearchButtonClick();

            var addButtons = yandexMarketPage.GetAddToComparisonButtons();
            yandexMarketPage.AddToComparison(addButtons[0]);
            yandexMarketPage.AddToComparison(addButtons[1]);

            yandexMarketPage.CompareButtonClick();

            var items = yandexMarketPage.GetItemsInComparisonList();
            Assert.AreEqual(2, items.Count, "Assert there are two item in the list to compare");

            yandexMarketPage.DeleteFromComparison();

            Assert.IsTrue(yandexMarketPage.GetNoItemsText().Displayed, "Assert text about empty comparison appeared");
        }

       
    }
}
