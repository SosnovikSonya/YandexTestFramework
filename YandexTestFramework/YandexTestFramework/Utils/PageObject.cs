using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace YandexTestFramework.Utils
{
    public abstract class PageObject
    {
        public PageObject(IWebDriver webDriver)
        {
            InitializePage(webDriver);
        }

        public IWebDriver WebDriver { get; protected set; }

        protected void InitializePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            //Initialize WebElements
            PageFactory.InitElements(webDriver, this);
        }
    }
}
