using Bytescout.Spreadsheet;
using HerfaTest.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.Helpers
{
    public class CommonMethods
    {
        public static void NavigateToURL(string url)
        {
            ManageDriver.driver.Navigate().GoToUrl(url);
        }


        public static IWebElement WaitAndFindElement(By by) //By firstName = By.XPath("//div/input[@id='Fname']");
        {
            var fluentWait = new DefaultWait<IWebDriver>(ManageDriver.driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };

            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = fluentWait.Until(x => x.FindElement(by));
            return element;
        }


        public static void HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: lightpink !important')", element);
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(1000);
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: none !important')", element);

        }

        public static Worksheet ReadExcel(string sheetName)
        {
            Spreadsheet Excel = new Spreadsheet();
            Excel.LoadFromFile(GlobalConstants.TestDataPath);
            Worksheet worksheet = Excel.Workbook.Worksheets.ByName(sheetName);
            return worksheet;
        }

        public static void TakeScreenShot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;
            Screenshot  screenshot = takesScreenshot.GetScreenshot();
        }
    }
}
