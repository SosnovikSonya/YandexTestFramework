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
    public class YandexVideoPage : PageObject
    {
        public YandexVideoPage(IWebDriver webDriver) : base(webDriver) { }
        PageElementsActions pageElementsActions = new PageElementsActions();

        [FindsBy(How = How.XPath, Using = "//div[text()='Видео']/..")]
        private IWebElement TabVideo { get; set; }

        public IWebElement GetTabVideo()
        {
            return pageElementsActions.GetWebElement(TabVideo);
        }
    }
}
