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
    public class YandexTranslatorPage : PageObject
    {
        public YandexTranslatorPage(IWebDriver webDriver) : base(webDriver) { }
        PageElementsActions pageElementsActions = new PageElementsActions();

        [FindsBy(How = How.XPath, Using = "//*[@class='name']")]
        private IWebElement LogoTranslator { get; set; }

        public IWebElement GetLogoTranslator()
        {
            return pageElementsActions.GetWebElement(LogoTranslator);
        }
    }
}
