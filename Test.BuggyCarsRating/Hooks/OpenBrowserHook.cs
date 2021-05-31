using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Test.BuggyCarsRating.Base;
using Test.BuggyCarsRating.Contexts;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static Test.BuggyCarsRating.Base.Browser;

namespace Test.BuggyCarsRating.Hooks
{
    [Binding]
    public sealed class OpenBrowserHook
    {
        private DriverContext _driverContext;
        public OpenBrowserHook(DriverContext driverContext) => _driverContext = driverContext;

        public void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    _driverContext.Driver = new InternetExplorerDriver();
                    _driverContext.browser = new Browser(_driverContext);
                    break;
                case BrowserType.FireFox:
                    FirefoxOptions option2 = new FirefoxOptions();
                    option2.AddArguments("start-maximized");
                    option2.AddArguments("--disable-gpu");
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driverContext.Driver = new FirefoxDriver();
                    _driverContext.browser = new Browser(_driverContext);
                    break;
                case BrowserType.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    option.AddArguments("start-maximized");
                    option.AddArguments("--disable-gpu");
                    option.AddArguments("--headless");
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driverContext.Driver = new ChromeDriver(option);
                    _driverContext.browser = new Browser(_driverContext);
                    _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    break;
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            OpenBrowser(BrowserType.Chrome);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverContext.Driver.Quit();
        }
    }
}
