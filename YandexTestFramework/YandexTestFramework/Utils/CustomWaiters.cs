using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTestFramework.Configuration;

namespace YandexTestFramework.Utils
{
    class CustomWaiters
    {
        private CustomElementConditions elementCondition;

        /// <summary>
        /// Ждать пока элемент станет видимым
        /// Явное ожидание
        /// </summary>
        public void WaitUntilVisible(IWebElement element)
        {
            elementCondition = new CustomElementConditions();
            try
            {
                new WebDriverWait(DriverProvider.Driver, TimeSpan.FromSeconds(30))
                    .Until(d => elementCondition.IsElementPresentAndVisible(element));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Timed out waiting for the item to appear: '{element}'\n Exception: {ex}");
                throw new TimeoutException($"Timed out waiting for the item to appear: {element}\n", ex);
            }
        }

        /// <summary>
        /// Ожидает когда элемент станет кликабельным и возвращаем элемент
        /// </summary>
        public IWebElement WaitUntilClickable(IWebElement element)
        {
            elementCondition = new CustomElementConditions();
            try
            {
                return new WebDriverWait(DriverProvider.Driver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"The element has timed out to be clickable: '{element}'\n Exception: {ex}");
                throw new TimeoutException($"The element has timed out to be clickable: {element}\n", ex);
            }
        }

        /// <summary>
        /// Ждать пока все элементы станут видимыми
        /// Явное ожидание
        /// </summary>
        public void WaitUntilAllElementsVisible(IList<IWebElement> elements)
        {
            var readOnlyList = new ReadOnlyCollection<IWebElement>(elements);
            elementCondition = new CustomElementConditions();
            try
            {
                new WebDriverWait(DriverProvider.Driver, TimeSpan.FromSeconds(30))
                    .Until(d => SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(readOnlyList));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Timed out waiting for the item to appear \n Exception: {ex}");
                throw new TimeoutException($"Timed out waiting for the item to appear \n", ex);
            }
        }
    }
}
