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

########

Scenario: Cart is activated on selecting a pizza
	Given I have an empty cart
	When I select a pizza
	Then the cart should be activated
	
Scenario: Card displays name and quantity of selected pizzas
	Given my cart contains the following pizzas
		| name       | quantity |
		| BBQ        | 1        |
		| Margherita | 2        |
	When I check the cart
	Then the following items should be listed
		| name       | quantity |
		| BBQ        | 1        |
		| Margherita | 2        |
		