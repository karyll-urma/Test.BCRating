using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Test.BuggyCarsRating.Base;

using Test.BuggyCarsRating.Contexts;
using Test.BuggyCarsRating.Helpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static Test.BuggyCarsRating.Base.Browser;

namespace Test.BuggyCarsRating.Hooks
{
    [Binding]
    public sealed class InitializeHook
    {
        private DriverContext _driverContext;

        public InitializeHook(DriverContext driverContext) => _driverContext = driverContext;

        //Initialize
        public static void InitializeSettings()
        {
            // Read settings file
            SettingsReaderHelper.SetFrameworkSettings();
            
            //Set Log
            LogHelper.CreateLogFile();
            LogHelper.Write("Initialized framework");
        }
        
        // Select Browser and configurations
        public void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    _driverContext.Driver = new InternetExplorerDriver();
                    _driverContext.browser = new Browser(_driverContext);
                    _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWait);
                    break;
                case BrowserType.FireFox:
                    FirefoxOptions optionff = new FirefoxOptions();
                    optionff.AddArguments("start-maximized");
                    optionff.AddArguments("--disable-gpu");
                    if (Settings.IsHeadless)
                    {
                        optionff.AddArguments("--headless");
                    }

                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driverContext.Driver = new FirefoxDriver(optionff);
                    _driverContext.browser = new Browser(_driverContext);
                    _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWait);
                    break;
                case BrowserType.Chrome:
                    ChromeOptions optionc = new ChromeOptions();
                    optionc.AddArguments("start-maximized");
                    optionc.AddArguments("--disable-gpu");
                    if (Settings.IsHeadless)
                    {
                        optionc.AddArguments("--headless");
                    }

                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driverContext.Driver = new ChromeDriver(optionc);
                    _driverContext.browser = new Browser(_driverContext);
                    _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWait);
                    break;
            }
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {          
            InitializeSettings();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            OpenBrowser(Settings.Browser);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverContext.Driver.Quit();
        }
    }
}
