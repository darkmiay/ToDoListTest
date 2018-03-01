using OpenQA.Selenium;
using ToDoListTest.PageSteps;

namespace ToDoListTest
{    
    class BaseSteps
    {
        protected MainSteps steps;
        protected IWebDriver driver;


       protected void Init()
        {
            driver = WebDriverConcurrent.InitDriver(this.GetType());
            steps = new MainSteps(driver);
        }

        protected void End()
        {
            WebDriverConcurrent.KillDriver(this.GetType());
        }

    }
}
