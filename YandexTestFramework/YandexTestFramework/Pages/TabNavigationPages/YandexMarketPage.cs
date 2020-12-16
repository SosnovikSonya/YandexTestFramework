using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;
using YandexTestFramework.Utils;
using YandexTestFramework.Utils.Actions;

namespace YandexTestFramework.Pages.TabNavigationPages
{
    public class YandexMarketPage : PageObject
    {
        public YandexMarketPage(IWebDriver webDriver) : base(webDriver) { }
        PageElementsActions pageElementsActions = new PageElementsActions();
        MouseActions mouseActions = new MouseActions();

        [FindsBy(How = How.XPath, Using = "//*[@id='logoPartMarket']")]
        private IWebElement LogoMarket { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='header-search']")]
        private IWebElement SearchText { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='_1XiEJDPVpk']")]
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='_1CXljk9rtd']")]
        private IList<IWebElement> AddToComparisonButtons { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Сравнить')]/..")]
        private IWebElement CompareButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='zvRJMhRW-w']")]
        private IList<IWebElement> ItemsInComparison { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='MOYcCv2eIJ _1KU3sPkiT1']")]
        private IWebElement DeleteListOfItems { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='_2szVRO2K75']")]
        private IWebElement NoItemsText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Бытовая техника']/..")]
        private IWebElement HouseholdTechTabMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@data-autotest-id ='dprice']")]
        private IWebElement SortByCostLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, '_2Sc2mRSDwb')]")]
        private IList<IWebElement> ItemsCosts { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='" + TestData.categoryToSort + "']/..")]
        private IWebElement CategoryToSortByTag { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='15464317to']")]
        private IWebElement WidthInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='_1leWQd9vBF _2_oj-OEI-o']/li[contains(text(), 'ШхВхГ')]")]
        private IList<IWebElement> ItemFeatures { get; set; }

        public IWebElement GetLogoMarket()
        {
            return pageElementsActions.GetWebElement(LogoMarket);
        }

        public void EnterSearchText(string text)
        {
            pageElementsActions.InputDataInTheField(SearchText, text);
        }

        public YandexMarketPage SearchButtonClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(SearchButton);
            return new YandexMarketPage(WebDriver);
        }

        public IList<IWebElement> GetAddToComparisonButtons()
        {
            return pageElementsActions.GetWebElements(AddToComparisonButtons);
        }

        public void AddToComparison(IWebElement ComparisonButton)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)DriverProvider.Driver;
            executor.ExecuteScript("arguments[0].click();", ComparisonButton);
            //mouseActions.MoveMouseTo(DriverProvider.Driver, ComparisonButton);
            //mouseActions.MouseClick(DriverProvider.Driver, ComparisonButton);
        }

        public YandexMarketPage CompareButtonClick()
        {
            var element = pageElementsActions.FindElementOrReturnNullBy(By.XPath("//*[contains(text(), 'Сравнить')]"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)DriverProvider.Driver;
            executor.ExecuteScript("arguments[0].click();", element);
            return new YandexMarketPage(WebDriver);
        }

        public IList<IWebElement> GetItemsInComparisonList()
        {
            return pageElementsActions.GetWebElements(ItemsInComparison);
        }

        public void DeleteFromComparison()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(DeleteListOfItems);
        }

        public IWebElement GetNoItemsText()
        {
            return pageElementsActions.GetWebElement(NoItemsText);
        }

        public void SortByCostLinkClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(SortByCostLink);
        }

        public IList<IWebElement> GetItemsCosts()
        {
            return pageElementsActions.GetWebElements(ItemsCosts);
        }

        public string GetItemsCostText(IWebElement webElement)
        {
            return pageElementsActions.GetTextFromElement(webElement);
        }

        public void HouseholdTechTabMenuClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(HouseholdTechTabMenu);
        }

        public void CategoryToSortByTagClick()
        {
            pageElementsActions.ClickTheButtonWhenIsClickable(CategoryToSortByTag);
        }

        public void EnterWidthInput(string width)
        {
            pageElementsActions.InputDataInTheFieldAndPressEnter(WidthInput, width);
        }

        public IList<IWebElement> GetItemFeatures()
        {
            return pageElementsActions.GetWebElements(ItemFeatures);
        }
    }
}
