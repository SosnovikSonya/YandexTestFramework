using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTestFramework.Utils
{
    class CustomElementConditions
    {
        public bool IsElementPresentAndVisible(IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is ElementNotVisibleException || ex is StaleElementReferenceException)
                {
                    return false;
                }
                if (ex.InnerException != null && ex.InnerException is StaleElementReferenceException)
                {
                    return false;
                }
                throw ex;
            }
        }

        public bool IsElementEnabled(IWebElement webElement)
        {
            try
            {
                return webElement.Enabled;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is ElementNotVisibleException || ex is StaleElementReferenceException)
                {
                    return false;
                }
                if (ex.InnerException != null && ex.InnerException is StaleElementReferenceException)
                {
                    return false;
                }
                throw ex;
            }
        }
    }
}
