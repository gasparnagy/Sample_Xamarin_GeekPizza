Feature: Pizza Selection

Rule: Should be able to select pizzas
* Select a pizza
* Select multiple pizzas
* Select the same pizza multiple times

Scenario: Select a pizza
	Given I have an empty cart
	When I select the "Margherita" pizza
	Then the cart should contain an "Margherita" pizza

Scenario: Select multiple pizzas
	Given I have a cart with an "Margherita" pizza
	When I select the "BBQ" pizza
	Then the cart should contain an "Margherita" pizza
	And the cart should contain an "BBQ" pizza

Scenario: Select the same pizza multiple times
	Given I have a cart with an "Margherita" pizza
	When I select the "Margherita" pizza
	Then the cart should contain 2 "Margherita" pizzas
		