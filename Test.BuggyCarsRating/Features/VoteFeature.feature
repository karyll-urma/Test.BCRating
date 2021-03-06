Feature: VoteFeature
	This feature is to test the Vote functionality of the application.

@NoDefects
Scenario Outline: S01_Vote_IncrementValidation
	Given User navigate to application
	And User successfully register to the application
		| Login           | FirstName | LastName | Password   | ConfirmPassword | Message                    |
		| RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | Registration is successful |
	And User successfully login to the application	
	When User navigate to Make'<Make>' Model'<Model>'
	And User input a comment '<Comment>' and Vote
	Then User can see Vote counts increment by 1

	Examples:
		| Scenario      | Make        | Model    | Comment          |
		| TC01_GALLARDO | Lamborghini | GALLARDO | This is my vote! |
		| TC02_Huayra   | Pagani      | Huayra   | This is my vote! |
		| TC03_Ypsilon  | Lancia      | Ypsilon  | This is my vote! |

@NoDefects
Scenario Outline: S02_Vote_TwiceSameCar
	Given User navigate to application
	And User successfully register to the application
		| Login           | FirstName | LastName | Password   | ConfirmPassword | Message                    |
		| RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | Registration is successful |
	And User successfully login to the application	
	When User navigate to Make'<Make>' Model'<Model>'
	And User input a comment '<Comment>' and Vote
	Then User can see Vote counts increment by 1
	When User navigate to Make'<Make>' Model'<Model>'
	Then User will not be able to vote again on same car

	Examples:
		| Scenario      | Make        | Model    | Comment          |
		| TC01_GALLARDO | Lamborghini | GALLARDO | This is my vote! |
		| TC02_Huayra   | Pagani      | Huayra   | This is my vote! |
		| TC03_Ypsilon  | Lancia      | Ypsilon  | This is my vote! |


Scenario: S03_Vote_Logout_ExitLastTrasaction
	Given User navigate to application
	And User successfully register to the application
		| Login           | FirstName | LastName | Password   | ConfirmPassword | Message                    |
		| RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | Registration is successful |
	And User successfully login to the application	
	When User navigate to Make'Lamborghini' Model'GALLARDO'
	And User input a comment 'This is my vote!' and Vote
	Then User can see Vote counts increment by 1
	When User click logout link
	Then User is logged out successfully
	And User exited the last transaction