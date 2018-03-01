using ToDoListTest.Page;
using OpenQA.Selenium;

namespace ToDoListTest.PageSteps
{
    class MainSteps
    {
        private ToDoListPage  _mainPage;
        public MainSteps(IWebDriver driver)
        {
            _mainPage = new ToDoListPage(driver);
        }

        public void Navigate()
        {
            _mainPage.NavigateHere();
        }

        public void AddToDo(string name)
        {
            _mainPage.AddToDo(name);
        }

        public bool IsToDoExist(string name)
        {
           return _mainPage.IsToDoExist(name);
        }

        public void ToggleAll()
        {
            _mainPage.ToggleAllToDo();
        }

        public void ClearCompleted()
        {
            _mainPage.ClearCompletedToDo();
        }

        public void Delete(string name)
        {
            _mainPage.DeleteToDo(name);
        }

        public void Edit(string oldName, string newName)
        {
            _mainPage.EditToDo(oldName, newName);
        }

        public void Toggle(string name)
        {
            _mainPage.ToggleToDo(name);
        }

        public void ShowActive()
        {
            _mainPage.ShowActiveToDo();
        }

        public void ShowCompleted()
        {
            _mainPage.ShowCompletedToDo();
        }

        public bool IsCompleted(string name)
        {
            return _mainPage.IsToDoCompleted(name);
        }
    }
}
