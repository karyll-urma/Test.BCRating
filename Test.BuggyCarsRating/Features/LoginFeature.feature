Feature: LoginFeature
	This feature is to test the Login functionality of the application.

@mytag
Scenario Outline: S01_Login_Valid
	Given User navigate to application
	When User login using credentials
		| Login   | Password   |
		| <Login> | <Password> |
	Then User successfully logged in
	And User able to see homepage

	Examples:
		| Scenario            | Login     | Password     |
		| TC01_RegisteredUser | Login0915 | September15! |

@mytag
Scenario Outline: S02_Login_Invalid
	Given User navigate to application
	When User login using credentials
		| Login   | Password   |
		| <Login> | <Password> |
	Then User able to see message Invalid username/password

	Examples:
		| Scenario              | Login        | Password  |
		| TC01_UnregisteredUser | Unregistered | test      |
		| TC02_SwapInput        | September15! | Login0915 |

@mytag
Scenario Outline: S03_Login_EmptyCredentials
	Given User navigate to application
	When User login using credentials
		| Login   | Password   |
		| <Login> | <Password> |
	Then User not successfully logged in

	Examples:
		| Scenario           | Login     | Password     |
		| TC01_EmptyLogin    |           | September15! |
		| TC02_EmptyPassword | Login0915 |              |

@NoDefects
Scenario: S04_Login_NewlyRegisteredUser
	Given User navigate to application
	When User select Register button
	And User enter user credential
		| Login           | FirstName | LastName | Password   | ConfirmPassword | 
		| RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | 
	And User click register button
	Then User can see the message 'Registration is successful'
	When User login in the application
	Then User successfully logged in

@mytag
Scenario: S05_Register_Login_HomeScreenValidation
	Given User navigate to application
	When User select Register button
	And User enter user credential
		| Login           | FirstName | LastName | Password   | ConfirmPassword |
		| RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | 
	And User click register button
	Then User can see the message 'Registration is successful'
	When User login in the application
	Then User successfully logged in
	And User able to see homepage