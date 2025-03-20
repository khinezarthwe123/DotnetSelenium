using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotnetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Sudo code for setting up Selenium

            //Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();

            //Naviage to the URL
            driver.Navigate().GoToUrl("https://www.google.com/");

            //Maximize the browser window
            driver.Manage().Window.Maximize();

            //Find the element
            IWebElement webElement = driver.FindElement(By.Name("q"));

            //Type in the element
            webElement.SendKeys("Selenium");

            //Click on the element
            webElement.SendKeys(Keys.Return);

            webElement.Click();
        }

        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("www.google.com");
            var loginlink = driver.FindElement(By.Id("login"));
            loginlink.Click();

            IWebElement txtUserName = driver.FindElement(By.Name("User Name"));
            txtUserName.SendKeys("admin");

            IWebElement txtPassword = driver.FindElement(By.Name("Password"));
            txtPassword.SendKeys("password");

            //IWebElement btnLogin = driver.FindElement(By.ClassName("btn"));
            //OR
            IWebElement btnLogin = driver.FindElement(By.CssSelector(".btn"));
            btnLogin.Submit();

        }

        [Test]
        public void LoginTestReduceCode()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("www.xxx.com");

            //driver.FindElement(By.Name("User Name")).SendKeys("admin");
            //driver.FindElement(By.Name("Password")).SendKeys("password");
            //OR
            SeleniumCustomMethod.EnterText(driver, By.Name("User Name"), "admin");
            SeleniumCustomMethod.EnterText(driver, By.Name("Password"), "password");

            driver.FindElement(By.CssSelector(".btn")).Submit();
        }

        [Test]
        public void WorkingWithAdvancedControls()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("www.xxx.com");

            //Normal DropDown
            //SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("dropdown")));
            //selectElement.SelectByText("Option 2");
            SeleniumCustomMethod.SelectDropDownByText(driver, By.Id("dropdown"), "Option 2");

            //MultiSelect DropDown
            //SelectElement multiselect= new SelectElement(driver.FindElement(By.Id("multiSelect")));
            //multiselect.SelectByValue("multi1");
            //multiselect.SelectByValue("multi2");
            SeleniumCustomMethod.MultiSelectElements(driver, By.Id("multiSelect"), ["multi1", "multi2"]);

            //var list = multiselect.AllSelectedOptions;
            //foreach (var option in list)
            //{
            //    Console.WriteLine(option.Text);
            //}
            var getSelectedOption = SeleniumCustomMethod.GetAllSelectedList(driver, By.Id("multiSelect"));
            getSelectedOption.ForEach(Console.WriteLine);

            SeleniumCustomMethod.Click(driver, By.Id("LoginLink"));

        }
    }
}