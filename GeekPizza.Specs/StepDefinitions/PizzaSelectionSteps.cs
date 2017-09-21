using System;
using System.Linq;
using GeekPizza.Services;
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
        private readonly Store _store = new Store(new MockRestaurant());
        private readonly NavigationStub navigationStub = new NavigationStub();

        [BeforeScenario]
        public void InitializeApp()
        {
            ContentBasePage.IsTesting = true;
            _store.InitializeAsync().Wait();
        }

        [Given(@"I have an empty cart")]
        public void GivenIHaveAnEmptyCart()
        {
            CollectionAssert.IsEmpty(_store.Order.Items);
        }

        [Given(@"I have a cart with an ""(.*)"" pizza")]
        public void GivenIHaveACartWithAnPizza(string pizzaName)
        {
            _store.AddToCart(_store.PizzaMenuItems.First(i => i.Name == pizzaName));
        }

        [Given(@"my cart contains the following pizzas")]
        public void GivenMyCartContainsTheFollowingPizzas(Table table)
        {
            foreach (var row in table.Rows)
            {
                var quantity = int.Parse(row["quantity"]);
                for (int i = 0; i < quantity; i++)
                {
                    GivenIHaveACartWithAnPizza(row["name"]);
                }
            }
        }

        [When(@"I select the ""(.*)"" pizza")]
        public void WhenISelectThePizza(string pizzaName)
        {
            var viewModel = new PizzaMenuViewModel(_store)
            {
                Navigation = navigationStub
            };

            var pizzaItem = viewModel.Items.FirstOrDefault(i => i.Name == pizzaName);
            viewModel.ItemTappedCommand.Execute(pizzaItem);
        }

        [When(@"I select a pizza")]
        public void WhenISelectAPizza()
        {
            WhenISelectThePizza("Uncle Bob's FitNesse");
        }


        [Then(@"the cart should be activated")]
        public void ThenTheCartShouldBeActivated()
        {
            Assert.IsInstanceOf<CartPage>(navigationStub.CurrentPage);
        }

        [Then(@"the cart should contain an ""(.*)"" pizza")]
        public void ThenTheCartShouldContainAnPizza(string expectedPizzaName)
        {
            ThenTheCartShouldContainPizzas(1, expectedPizzaName);
        }

        [Then(@"the cart should contain (.*) ""(.*)"" pizzas")]
        public void ThenTheCartShouldContainPizzas(int expectedQuantity, string expectedPizzaName)
        {
            EnsureCartViewModel();

            var cartItem = cartViewModel.Items.FirstOrDefault(i => i.Pizza.Name == expectedPizzaName);
            Assert.IsNotNull(cartItem, "there should be a pizza <{0}> in the cart", expectedPizzaName);
            Assert.AreEqual(expectedQuantity, cartItem.Quantity, "the quantity of the <{0}> pizza in the cart should be {1}", expectedPizzaName, expectedQuantity);
        }

        private CartViewModel cartViewModel;

        private void EnsureCartViewModel()
        {
            if (cartViewModel != null)
                return;
            cartViewModel = new CartViewModel(_store)
            {
                Navigation = navigationStub
            };
        }

        [When(@"I check the cart")]
        public void WhenICheckTheCart()
        {
            EnsureCartViewModel();
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
