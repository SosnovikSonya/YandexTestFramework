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
    public class YandexNewsPage : PageObject
    {
        public YandexNewsPage(IWebDriver webDriver) : base(webDriver) { }
        PageElementsActions pageElementsActions = new PageElementsActions();

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'navigation__item_name_news')]")]
        private IWebElement TabNews { get; set; }

        public IWebElement GetTabNews()
        {
            return pageElementsActions.GetWebElement(TabNews);
        }
    }
}
