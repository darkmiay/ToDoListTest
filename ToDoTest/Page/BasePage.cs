using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ToDoListTest.Page
{
    class BasePage
    {
        protected string BaseURL = "http://todomvc.com/examples/angularjs/#/";
        protected IWebDriver driver;
        protected Actions actions;

        public BasePage(IWebDriver Driver)
        {
            this.driver = Driver;
            this.actions = new Actions(Driver);
        }

        public void NavigateHere()
        {
            driver.Navigate().GoToUrl(BaseURL);
        }
    }
}
