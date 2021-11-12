Feature: GetResponses
	As example of this API framework
	After sending adequate requests
	I want to get response status and adequate body
	#And with example of deserialization I should represent posibilities which deserialization offer for future assertions

Scenario: Get HTTP response Status 200
	Given I create request with parameter 'q' and its value 'Sombor'
	When I send this request
	Then Result should be response Status 200

Scenario: Get adequate body of the response
	Given I create request with parameter 'q' and its value 'Sombor'
	When I send this request
	Then  Result should be adequate body
	And City in response should be 'Sombor'