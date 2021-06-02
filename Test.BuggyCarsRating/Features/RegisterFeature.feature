Feature: RegisterFeature
	This feature is to test the Registration functionality of the application.

Scenario Outline: S01_Registration_ValidCredentials
	Given User navigate to application
	When User select Register button
	And User enter user credential
		| Login   | FirstName   | LastName   | Password   | ConfirmPassword   |
		| <Login> | <FirstName> | <LastName> | <Password> | <ConfirmPassword> |
	And User click register button
	Then User can see the message '<Message>'

	Examples:
		| Scenario               | Login           | FirstName | LastName | Password   | ConfirmPassword | Message                    |
		| TC01_PasswordMatch     | RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | Registration is successful |
		| TC02_PasswordWith6Char | RandomString-10 | 1FN0915   | 1LN0915  | Abcd1!     | Abcd1!          | Registration is successful |
		| TC03_PasswordWith7Char | RandomString-10 | 1FN0915   | 1LN0915  | Abcd12!    | Abcd12!         | Registration is successful |
		| TC04_PasswordWith8Char | RandomString-10 | 1FN0915   | 1LN0915  | Abcd123!   | Abcd123!        | Registration is successful |

#Failing due to Error Messages not diplayed when fields left empty.
Scenario Outline: S02_Registration_EmptyCredentials
	Given User navigate to application
	When User select Register button
	And User enter user credential
		| Login   | FirstName   | LastName   | Password   | ConfirmPassword   |
		| <Login> | <FirstName> | <LastName> | <Password> | <ConfirmPassword> |
	Then User can see the message '<Message>'

	Examples:
		| Scenario                  | Login           | FirstName | LastName | Password   | ConfirmPassword | Message                |
		| TC01_EmptyLogin           |                 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | Login is required      |
		| TC02_EmptyFirstName       | RandomString-10 |           | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | First Name is required |
		| TC03_EmptyLastName        | RandomString-10 | 1FN0915   |          | Abcdefgh1! | Abcdefgh1!      | Last Name is required  |
		| TC04_EmptyPassword        | RandomString-10 | 1FN0915   | 1LN0915  |            | Abcdefgh1!      | Password is required   |
		| TC05_EmptyConfirmPassword | RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! |                 | Passwords do not match |

#WorkAround - Added step to add a text and delete to validate error messages.
Scenario Outline: S02_Registration_EmptyCredentials_WorkAround
	Given User navigate to application
	When User select Register button
	And User enter user credential - with workaround
		| Login   | FirstName   | LastName   | Password   | ConfirmPassword   |
		| <Login> | <FirstName> | <LastName> | <Password> | <ConfirmPassword> |
	Then User can see the message '<Message>'

	Examples:
		| Scenario                  | Login           | FirstName | LastName | Password   | ConfirmPassword | Message                |
		| TC01_EmptyLogin           |                 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | Login is required      |
		| TC02_EmptyFirstName       | RandomString-10 |           | 1LN0915  | Abcdefgh1! | Abcdefgh1!      | First Name is required |
		| TC03_EmptyLastName        | RandomString-10 | 1FN0915   |          | Abcdefgh1! | Abcdefgh1!      | Last Name is required  |
		| TC04_EmptyPassword        | RandomString-10 | 1FN0915   | 1LN0915  |            | Abcdefgh1!      | Password is required   |
		| TC05_EmptyConfirmPassword | RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! |                 | Passwords do not match |

@NoDefects
Scenario Outline: S03_Registration_PasswordMinCriteriaNotMet
	Given User navigate to application
	When User select Register button
	And User enter user credential
		| Login   | FirstName   | LastName   | Password   | ConfirmPassword   |
		| <Login> | <FirstName> | <LastName> | <Password> | <ConfirmPassword> |
	And User click register button
	Then User can see the message '<Message>'

	Examples:
		| Scenario                        | Login           | FirstName | LastName | Password   | ConfirmPassword | Message                                                                     |
		| TC01_PasswordMismatch           | RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefghi1!     | Passwords do not match                                                      |
		| TC02_Password5Char              | RandomString-10 | 1FN0915   | 1LN0915  | Abc1!      | Abc1!           | minimum field size of 6, SignUpInput.Password                               |
		| TC03_PasswordWithoutSpecialChar | RandomString-10 | 1FN0915   | 1LN0915  | Abcdefg1   | Abcdefg1        | Password did not conform with policy: Password must have symbol characters  |
		| TC04_PasswordWithoutNumeric     | RandomString-10 | 1FN0915   | 1LN0915  | Abcdefg!   | Abcdefg!        | Password did not conform with policy: Password must have numeric characters |

@NoDefects
Scenario: S04_Registration_SameUserTwice
	Given User navigate to application
	When User select Register button
	And User enter user credential
		| Login           | FirstName | LastName | Password   | ConfirmPassword |
		| RandomString-10 | 1FN0915   | 1LN0915  | Abcdefgh1! | Abcdefgh1!      |
	And User click register button
	Then User can see the message 'Registration is successful'
	When User select Register button
	And User enter the same user
	And User click register button
	Then User can see the message 'UsernameExistsException: User already exists'