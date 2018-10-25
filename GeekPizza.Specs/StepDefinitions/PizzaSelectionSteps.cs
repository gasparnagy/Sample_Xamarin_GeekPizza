using System;
using System.Linq;
using GeekPizza.Services;
using GeekPizza.Specs.Drivers;
using GeekPizza.Specs.Support;
using GeekPizza.ViewModels;
using GeekPizza.Views;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GeekPizza.Specs.StepDefinitions
{
    [Binding]
    public class PizzaSelectionSteps
    {
        private readonly IAppDriver _appDriver;

        public PizzaSelectionSteps(IAppDriver appDriver)
        {
            _appDriver = appDriver;
        }

        [Given(@"I have an empty cart")]
        public void GivenIHaveAnEmptyCart()
        {
            //CollectionAssert.IsEmpty(_store.Order.Items);
        }

        [Given(@"I have a cart with an ""(.*)"" pizza")]
        public void GivenIHaveACartWithAnPizza(string pizzaName)
        {
            _appDriver.EnsureItemInCart(pizzaName, 1);
        }

        [Given(@"my cart contains the following pizzas")]
        public void GivenMyCartContainsTheFollowingPizzas(Table table)
        {
            foreach (var row in table.Rows)
            {
                _appDriver.EnsureItemInCart(
                    row["name"], 
                    int.Parse(row["quantity"]));
            }
        }

        [When(@"I select the ""(.*)"" pizza")]
        public void WhenISelectThePizza(string pizzaName)
        {
            _appDriver.SelectPizza(pizzaName);
        }

        [When(@"I select a pizza")]
        public void WhenISelectAPizza()
        {
            _appDriver.SelectPizza("Margherita");
        }

        [Then(@"the cart should be activated")]
        public void ThenTheCartShouldBeActivated()
        {
            Assert.IsTrue(_appDriver.IsOnCartPage);
        }

        [Then(@"the cart should contain an ""(.*)"" pizza")]
        public void ThenTheCartShouldContainAnPizza(string expectedPizzaName)
        {
            ThenTheCartShouldContainPizzas(1, expectedPizzaName);
        }

        [Then(@"the cart should contain (.*) ""(.*)"" pizzas")]
        public void ThenTheCartShouldContainPizzas(int expectedQuantity, string expectedPizzaName)
        {
            _appDriver.EnsureOnCartPage();
            var quantity = _appDriver.GetCartQuantity(expectedPizzaName);
            Assert.AreNotEqual(0, quantity, "there should be a pizza <{0}> in the cart", expectedPizzaName);
            Assert.AreEqual(expectedQuantity, quantity, "the quantity of the <{0}> pizza in the cart should be {1}", expectedPizzaName, expectedQuantity);
        }

        [When(@"I check the cart")]
        public void WhenICheckTheCart()
        {
            _appDriver.EnsureOnCartPage();
        }

        [Then(@"the following items should be listed")]
        public void ThenTheFollowingItemsShouldBeListed(Table expectedItemsTable)
        {
            foreach (var expectedItemRow in expectedItemsTable.Rows)
            {
                ThenTheCartShouldContainPizzas(int.Parse(expectedItemRow["quantity"]), expectedItemRow["name"]);
            }
        }

    }
}
