Feature: Pizza Selection

Rules:
* Should be able to select pizzas
	* Select a pizza
	* Select multiple pizzas
	* Select the same pizza multiple times
* Should display cart
	* Cart is activated on selecting a pizza
	* Card displays name and quantity of selected pizzas

Scenario: Select a pizza
	Given I have an empty cart
	When I select the "Uncle Bob's FitNesse" pizza
	Then the cart should contain an "Uncle Bob's FitNesse" pizza

Scenario: Select multiple pizzas
	Given I have a cart with an "Uncle Bob's FitNesse" pizza
	When I select the "Chris Matts' GWT" pizza
	Then the cart should contain an "Uncle Bob's FitNesse" pizza
	And the cart should contain an "Chris Matts' GWT" pizza

Scenario: Select the same pizza multiple times
	Given I have a cart with an "Uncle Bob's FitNesse" pizza
	When I select the "Uncle Bob's FitNesse" pizza
	Then the cart should contain 2 "Uncle Bob's FitNesse" pizzas

########

Scenario: Cart is activated on selecting a pizza
	Given I have an empty cart
	When I select a pizza
	Then the cart should be activated
	
Scenario: Card displays name and quantity of selected pizzas
	Given my cart contains the following pizzas
		| name                 | quantity |
		| Chris Matts' GWT     | 1        |
		| Uncle Bob's FitNesse | 2        |
	When I check the cart
	Then the following items should be listed
		| name                 | quantity |
		| Chris Matts' GWT     | 1        |
		| Uncle Bob's FitNesse | 2        |
		