using System;
using OpenQA.Selenium;

namespace ToDoListTest.Page
{
    class ToDoListPage : BasePage
    {

        #region Page Objects Xpath
        private readonly By _toDoInput = By.XPath("//*[@id='new-todo']");
        private readonly By _toggleAllCheckBox = By.XPath("//*[@id='toggle-all']");
        private readonly By _showAllCheckBox = By.XPath("//a [. = 'All']");
        private readonly By _showActiveCheckBox = By.XPath("//a [. = 'Active']");
        private readonly By _showCompletedCheckBox = By.XPath("//a [. = 'Completed']");
        private readonly By _clearCompleted = By.XPath("//*[@id='clear-completed']");
        private readonly By _activeToDoCount = By.XPath("//*[@id='todo-count']/strong");
        private readonly By _visibleToDo = By.XPath("//*[@id='todo-list']/li");
        private readonly By _editToDo = By.XPath("//li[@class='ng-scope editing']/form/input");
        #endregion

        public ToDoListPage(IWebDriver driver) : base(driver) { }

        public IWebElement FindToDo(string toDoName)
        {
          return driver.FindElement(By.XPath($"//label[. = '{toDoName}']"));
        }

        public bool IsToDoExist(string toDoName)
        {
            if (IsToDoListClear()) return false;
            return (driver.FindElement(By.XPath($"//label[. = '{toDoName}']")).Displayed);
        }

        public bool IsToDoCompleted(string toDoName)
        {
            return (driver.FindElement(By.XPath($"//label[. = '{toDoName}']/../../*"))
                .GetAttribute("class").ToString() != "ng-scope");
        }

        public IWebElement GetToDoDeleteButton(string toDoName)
        {
            return driver.FindElement(By.XPath($"//label[. = '{toDoName}']/following-sibling::button"));
        }

        public IWebElement GetToDoToggleCompleted(string toDoName)
        {
            return driver.FindElement(By.XPath($"//label[. = '{toDoName}']/preceding-sibling::input"));
        }

        public void DeleteToDo(string toDoName)
        {
            FindToDo(toDoName).Click();
            GetToDoDeleteButton(toDoName).Click();
        }

        public void AddToDo(string toDoName)
        {
            driver.FindElement(_toDoInput).SendKeys($@"{toDoName}{ Keys.Return}");
        }

        public void EditToDo(string toDoName, string newToDoName)
        {
            IWebElement toDo = FindToDo(toDoName);
            actions.DoubleClick(toDo).Perform();
            IWebElement edit = driver.FindElement(_editToDo);
            edit.Clear();
            edit.SendKeys(newToDoName);
            edit.Submit();        
        }

        public int GetActiveToDoCount()
        {
            return int.Parse(driver.FindElement(_activeToDoCount).Text);
        }

        public int GetVisibleToDoCount()
        {
            if (IsToDoListClear()) return 0;
            return Convert.ToInt32(driver.FindElements(_visibleToDo).Count);
            
        }

        public bool IsToDoListClear()
        {
            return (driver.FindElement(By.XPath("//*[@id = 'main']"))
            .GetAttribute("class").ToString() == "ng-hide");
        }

        public void ToggleToDo(string toDoName)
        {
            GetToDoToggleCompleted(toDoName).Click();
        }

        public void ToggleAllToDo()
        {
            driver.FindElement(_toggleAllCheckBox).Click();
        }

        public void ShowAllToDo()
        {
            driver.FindElement(_showAllCheckBox).Click();
        }

        public void ShowActiveToDo()
        {
            driver.FindElement(_showActiveCheckBox).Click();
        }

        public void ShowCompletedToDo()
        {
            driver.FindElement(_showCompletedCheckBox).Click();
        }

        public void ClearCompletedToDo()
        {
            driver.FindElement(_clearCompleted).Click();
        }

    }
}
