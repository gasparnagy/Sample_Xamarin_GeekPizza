Feature: Shopping Cart

Rule: Should display cart
* Cart is activated on selecting a pizza
* Card displays name and quantity of selected pizzas

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
