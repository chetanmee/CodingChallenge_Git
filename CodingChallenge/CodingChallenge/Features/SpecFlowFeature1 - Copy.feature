Feature: CarGaintFeature in order to test Watchlist functionality
As a tester
I want to ensure functionality is working end to end
@mytag
Scenario: cargiant should search for the given keyword and should navigate to search results page
Given I have navigated to cargiant website login page
And I have entered username 'meenalkuber@gmail.com' and password 'Test123' as valid userdetails to login
When search the Manufacturer Audi 
And add to the Watchlist
And Delete one of the watchlist
And search the Manufacturer Audi
Then Sort the List

