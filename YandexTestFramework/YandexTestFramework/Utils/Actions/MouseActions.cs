using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTestFramework.Utils.Actions
{
    public class MouseActions
    {
        public void MoveMouseToElementAndClick(IWebDriver driver, IWebElement element, int x, int y)
        {
            var customWaiters = new CustomWaiters();
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.MoveToElement(customWaiters.WaitUntilClickable(element), x, y).Click().Build().Perform();
        }

        public void MoveMouseTo(IWebDriver driver, IWebElement element)
        {
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.MoveToElement(element).Build().Perform();
        }

        public void MouseClick(IWebDriver driver, IWebElement element)
        {
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.Click(element).Build().Perform();
        }
    }
}
