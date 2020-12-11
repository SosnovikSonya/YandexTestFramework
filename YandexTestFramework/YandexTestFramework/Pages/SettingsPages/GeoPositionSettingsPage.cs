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
    public class GeoPositionSettingsPage : PageObject
    {
        public GeoPositionSettingsPage(IWebDriver webDriver) : base(webDriver) { }
        PageElementsActions pageElementsActions = new PageElementsActions();
        MouseActions mouseActions = new MouseActions();

        [FindsBy(How = How.XPath, Using = "//*[@id='city__front-input']")]
        private IWebElement City { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'b-autocomplete-item_type_geo')]")]
        private IWebElement CityResult { get; set; }

        public void EnterCity(string city)
        {
            pageElementsActions.InputDataInTheField(City, city);
        }

        public MainPage CityResultClick()
        {
            pageElementsActions.ClickTheButtonWhenIsVisible(CityResult);
            return new MainPage(WebDriver);
        }

        public MainPage ChangeCity(string city)
        {
            pageElementsActions.InputDataInTheField(City, city);
            mouseActions.MoveMouseTo(WebDriver, CityResult);
            mouseActions.MouseClick(WebDriver, CityResult);
            return new MainPage(WebDriver);
        }
    }
}
