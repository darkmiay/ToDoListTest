using System;
using System.Collections.Concurrent;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ToDoListTest
{
    class WebDriverConcurrent
    {
        private static readonly ConcurrentDictionary<Type, IWebDriver> DriverPool = new ConcurrentDictionary<Type, IWebDriver>();
        private static readonly string CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        public static IWebDriver InitDriver(Type type)
        {
            IWebDriver driver;
            if (!DriverPool.TryGetValue(type, out driver))
            {
                driver = InitChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(90));
                driver.Manage().Timeouts().PageLoad = (TimeSpan.FromSeconds(10));
                bool succesfullAdding = false;
                while (!succesfullAdding)
                {
                    succesfullAdding = DriverPool.TryAdd(type, driver);
                }
            }

            return driver;
        }

        private static IWebDriver InitChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            IWebDriver driver = new ChromeDriver(CurrentDirectory, options, TimeSpan.FromMinutes(3));
            return driver;
        }

        public static void KillDriver(Type type)
        {
            DriverPool[type].Quit();
            IWebDriver driver;

            bool isDriverRemoved = false;
            while (!isDriverRemoved)
            {
                isDriverRemoved = DriverPool.TryRemove(type, out driver);
            }
            driver = null;
        }
    }
}