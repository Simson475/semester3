# OOP exam 2020

## Student
Name: Simon Helming Nielsen
StudentNO: 20193578
Group: SW319E20

## Files And Projects
The programs is in two projects, one for the unit test and one for the Program
The  Program is split into 3 folders, one for the core of the line system, one for the user interface and one for the command parser which handles the connections and parsing the user input.
The core folder has sub folders for exceptions, classes and interfaces to keep it tidy with the bigger number og classes.

## Assumptions
- Not having to implement data persistence i read as not having to save the state between program launches
- I expect it to be a mistake that you should not be able to deactivate a seasonal product since the definition of the getter/setter states it should handle both
- I assume imported data will always be in the correct format, and have not implemented fail safes if they are not.
- I assume that the user is allowed to purchase on credit when the product allows it even though it is stated that we shouldnt elsewhere.
- GetTransactions have been renamed to GetBuyTransactions and only delivers BuyTransactions since the only place they are needed is when showing them to the user - and they should only be shown purchases.

## Frameworks
- [Nunit](https://nunit.org/) for testing purposes
- [NSubstitute](https://nsubstitute.github.io/) for mocking and stubs