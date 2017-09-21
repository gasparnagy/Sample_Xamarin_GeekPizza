Feature: Pizza Selection

Scenario: Select a pizza
	Given I have an empty cart
	When I select the "Uncle Bob's FitNesse" pizza
	Then the cart should be activated
	Then the cart should contain an "Uncle Bob's FitNesse" pizza
