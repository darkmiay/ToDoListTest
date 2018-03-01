using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ToDoListTest
{
    [Binding]
    class TestSteps : BaseSteps
    {
        private List<string> toDoPool;

        TestSteps()
        {
            toDoPool = new List<string>();
            toDoPool.Add("ToDo1");
            toDoPool.Add("ToDo2");
        }

        [Given(@"I navigate to the site")]
        public void GivenINavigateToTheSite()
        {
            steps.Navigate();
        }

        [Given(@"I add new ToDos")]
        public void GivenIAddNewToDos()
        {
           foreach(string name in toDoPool)
                steps.AddToDo(name);
        }

        [Then(@"I see new task at the ToDo list")]
        public void ThenISeeNewTaskAtTheToDoList()
        {
            Assert.IsTrue(steps.IsToDoExist(toDoPool[0]));

        }

        [When(@"I set all ToDo to completed")]
        public void WhenISetAllToDoToCompleted()
        {
            steps.ToggleAll();
        }

        [When(@"I clear completed")]
        public void WhenIClearCompleted()
        {
            steps.ClearCompleted();
        }

        [When(@"I delete added ToDo")]
        public void WhenIDeleteAddedToDo()
        {
            foreach (string name in toDoPool)
            steps.Delete(name);
        }

        [Then(@"I dont see deleted ToDo in the list")]
        public void ThenIDontSeeDeletedToDoInTheList()
        {
            Assert.IsFalse(steps.IsToDoExist(toDoPool[0]));

        }

        [When(@"I change added ToDo name")]
        public void WhenIChangeAddedToDoName()
        {
            steps.Edit(toDoPool[0], "Changed");
        }


        [Then(@"I see ToDo with changed name")]
        public void ThenISeeToDoWithChangedName()
        {
            Assert.IsTrue(steps.IsToDoExist("Changed"));

        }

        [When(@"I set half of ToDos to completed")]
        public void WhenISetHalfOfToDosToCompleted()
        {
            steps.Toggle(toDoPool[0]);
        }

        [When(@"I click on (.*) button")]
        public void WhenIClickOnActiveButton(string type)
        {
            if (type == "Active")
            {
                steps.ShowActive();
            }
            else
            {
                steps.ShowCompleted();
            }
        }

        [Then(@"I see only (.*) ToDos")]
        public void ThenISeeOnlyActiveToDos(string type)
        {
            if (type == "Active")
            {
                Assert.IsTrue(steps.IsCompleted(toDoPool[1]));
            }
            else
            {
                Assert.IsTrue(steps.IsCompleted(toDoPool[0]));
            }

        }

        [Then(@"I see all ToDos as completed")]
        public void ThenISeeAllToDosAsCompleted()
        {
            Assert.IsTrue(steps.IsCompleted(toDoPool[0]) && steps.IsCompleted(toDoPool[1]));

        }

        [When(@"I set ToDo to completed")]
        public void WhenISetToDoToCompleted()
        {
            steps.Toggle(toDoPool[0]);
        }      
        
        [Then(@"I see added ToDo as completed")]
        public void ThenISeeAddedToDoAsCompleted()
        {
            Assert.IsTrue(steps.IsCompleted(toDoPool[0]));

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Init();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            End();
        }
    }
}

