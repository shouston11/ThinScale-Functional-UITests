Feature: Challenging DOM

@Regression
Scenario: Check webpage can be loaded
	Given user navigates to the Challenging DOM url
	Then the correct page title is returned 'The Internet'

Scenario: Check the page header is displayed
	Given user navigates to the Challenging DOM url
	Then the correct page header is available 'Challenging DOM'

Scenario: Check the operation of the element "button" in blue and verify ID changes on click
	Given user navigates to the Challenging DOM url
	And clicks the blue button

Scenario: Check the operation of the element "button alert" in red and verify ID changes on click
	Given user navigates to the Challenging DOM url
	And clicks the red alert button

Scenario: check the operation of the element "button success" in green and verify ID changes on click
	Given user navigates to the Challenging DOM url
	And clicks the green success button

Scenario Outline: Check table headers are appearing correctly
	Given user navigates to the Challenging DOM url
	Then the following table headers should be appearing '<tableHeader>' 
	Examples: 
	| tableHeader |
	| Lorem       |
	| Ipsum       |
	| Dolor       |
	| Sit         |
	| Amet        |
	| Diceret     |
	| Action      |

Scenario Outline: Check first column elements in the table are appearing
	Given user navigates to the Challenging DOM url
	Then the following table headers should be appearing '<tableHeader>' 
	Examples: 
	| tableHeader |
	| Iuvaret0    |
	| Iuvaret1    |
	| Iuvaret2    |
	| Iuvaret3    |
	| Iuvaret4    |
	| Iuvaret5    |
	| Iuvaret6    |
    | Iuvaret7    |
	| Iuvaret8    |
	| Iuvaret9    |

Scenario: Check an edit button can be clicked and updates the url
	Given user navigates to the Challenging DOM url
	And clicks the edit button on the first line
	Then the url should update after click and contain '#edit'

Scenario: Check a delete button can be clicked and updates the url
	Given user navigates to the Challenging DOM url
	And clicks the delete button on the first line
	Then the url should update after click and contain '#delete'

Scenario: Check answer value changes on screen refresh
	Given user navigates to the Challenging DOM url
	Then refreshing the page should update the answer

Scenario: Check answer value updates when blue button is clicked
	Given user navigates to the Challenging DOM url
	Then Clicking the blue button should update the answer value

Scenario: Check answer value updates when red button is clicked
	Given user navigates to the Challenging DOM url
	Then Clicking the red button should update the answer value

Scenario: Check answer value updates when green button is clicked
	Given user navigates to the Challenging DOM url
	Then Clicking the green button should update the answer value