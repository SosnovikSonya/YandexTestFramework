using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTestFramework.Utils.Actions
{
    class WindowActions
    {
        public void SwitchBetweenWindows(IWebDriver driver, int tabIndex)
        {
            string parentHandle = driver.WindowHandles[0];
            string anyTabName = driver.WindowHandles[tabIndex];
            driver.SwitchTo().Window(anyTabName);
        }

        public string GetCurrentUrl(IWebDriver driver)
        {
            return driver.Url;
        }
    }
}
