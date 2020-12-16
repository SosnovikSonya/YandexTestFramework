using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;

namespace YandexTestFramework.Utils.Actions
{
    public class PageElementsActions
    {
        public void InputDataInTheField(IWebElement element, string data)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilVisible(element);
            CleanField(element);
            element.SendKeys(data);
        }

        public void InputDataInTheFieldAndPressEnter(IWebElement element, string data)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilVisible(element);
            CleanField(element);
            element.SendKeys(data + Keys.Enter);
        }

        public string GetTextFromElement(IWebElement element)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilVisible(element);
            return element.Text;
        }

        public void CleanField(IWebElement element)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilVisible(element);
            element.Clear();
        }

        public void ClickTheButtonWhenIsClickable(IWebElement element)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilClickable(element).Click();
        }

        public void ClickTheButtonWhenIsVisible(IWebElement element)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilVisible(element);
            element.Click();
        }

        public IWebElement GetWebElement(IWebElement element)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilVisible(element);
            return element;
        }

        public IList<IWebElement> GetWebElements(IList<IWebElement> elements)
        {
            var customWaiter = new CustomWaiters();
            customWaiter.WaitUntilAllElementsVisible(elements);
            return elements;
        }

        public IWebElement FindElementOrReturnNullBy(By by)
        {
            try
            {
                var wait = new WebDriverWait(DriverProvider.Driver, TimeSpan.FromSeconds(15));
                IWebElement el;
                el = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return el;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IWebElement> FindElementsBy(By by)
        {
            try
            {
                var el = new List<IWebElement>(new WebDriverWait(DriverProvider.Driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by)));
                return el;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Locator not found = \"{by.ToString()}\"\n Exception: {ex}");
                throw new NoSuchElementException($"Locator not found = \"{by.ToString()}\"\n", ex);
            }
        }
    }
}
