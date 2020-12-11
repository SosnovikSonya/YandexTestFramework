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
    public class YandexPicturesPage : PageObject
    {
        public YandexPicturesPage(IWebDriver webDriver) : base(webDriver) { }
        PageElementsActions pageElementsActions = new PageElementsActions();

        [FindsBy(How = How.XPath, Using = "//div[text()='Картинки']/..")]
        private IWebElement TabPictures { get; set; }

        public IWebElement GetTabPictures()
        {
            return pageElementsActions.GetWebElement(TabPictures);
        }
    }
}
