using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
