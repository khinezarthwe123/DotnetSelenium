using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium
{
    public class SeleniumCustomMethod
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void SelectDropDownByText(IWebDriver driver, By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(text);
        }

        public static void SelectDropDownByValue(IWebDriver driver, By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByValue(text);
        }

        public static void MultiSelectElements(IWebDriver driver, By locator, string[] values)
        {
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            foreach (var item in values)
            {
                multiSelect.SelectByValue(item);
            }
        }

        public static List<string> GetAllSelectedList(IWebDriver driver, By locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> list = multiSelect.AllSelectedOptions;
            foreach (var option in list)
            {
                options.Add(option.Text);
            }

            return options;
        }
    }
}
