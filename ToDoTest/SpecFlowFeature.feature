Feature: SpecFlowFeature
  As a Site user
  I want functional task list
  In order to better plan things 

Background: Go to the site and add new ToDo
    Given I navigate to the site
    And I add new ToDos

Scenario: Check for added todo exist
	Then I see new task at the ToDo list

Scenario: Delete added ToDo
	When I delete added ToDo
	Then I dont see deleted ToDo in the list

Scenario: Set all completed and clear completed
	When I set all ToDo to completed
	And I clear completed
	Then I dont see deleted ToDo in the list

Scenario: Change added ToDo name
	When I change added ToDo name
	Then I see ToDo with changed name

Scenario: Set all ToDo to completed
	When I set all ToDo to completed
	Then I see all ToDos as completed

Scenario: Set added ToDo to completed
	When I set ToDo to completed
	Then I see added ToDo as completed

Scenario Outline: Set half to completed and use filter button
	When I set half of ToDos to completed
	And I click on <type> button
	Then I see only <type> ToDos

	Examples: 
| type       |
| Active     |
| Completed  |

