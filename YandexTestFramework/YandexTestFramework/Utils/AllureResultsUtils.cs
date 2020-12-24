using OpenQA.Selenium;
using YandexTestFramework.Configuration;

namespace YandexTestFramework.Utils
{
    public static class AllureResultsUtils
    {
        public static void TakeScreenShot(string testName)
        {
            ((ITakesScreenshot)DriverProvider.Driver).GetScreenshot().SaveAsFile($"{testName}_screenshot.png", ScreenshotImageFormat.Png);
        }
    }
}
