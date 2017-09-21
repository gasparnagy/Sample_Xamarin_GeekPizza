using System;
using System.Linq;
using GeekPizza.Specs.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace GeekPizza.Specs.StepDefinitions
{
    [Binding, Scope(Tag = "mobile")]
    public class PizzaSelectionStepsMobile
    {
        private IApp app;

        [BeforeScenario]
        public void InitializeApp()
        {
            app = AppInitializer.StartApp(Platform.Android);
        }

        [Given(@"I have an empty cart")]
        public void GivenIHaveAnEmptyCart()
        {
            app.Screenshot("First screen.");
        }

        [Given(@"I have a cart with an ""(.*)"" pizza")]
        public void GivenIHaveACartWithAnPizza(string pizzaName)
        {
            WhenISelectThePizza(pizzaName);
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
            if (!IsOnPizzaMenuPage)
                app.Back();
            app.Tap(e => e.Marked("NameLabel").All().Text(pizzaName).Parent());
        }

        private bool IsOnPizzaMenuPage
        {
            get { return app.Query(e => e.Marked("Pizza Menu")).Any(); }
        }

        private bool IsOnCartPage
        {
            get { return !IsOnPizzaMenuPage &&
                    app.Query(e => e.Marked("Cart")).Any(); }
        }

        [When(@"I select a pizza")]
        public void WhenISelectAPizza()
        {
            WhenISelectThePizza("Uncle Bob's FitNesse");
        }

        [Then(@"the cart should contain an ""(.*)"" pizza")]
        public void ThenTheCartShouldContainAnPizza(string expectedPizzaName)
        {
            ThenTheCartShouldContainPizzas(1, expectedPizzaName);
        }

        [Then(@"the cart should contain (.*) ""(.*)"" pizzas")]
        public void ThenTheCartShouldContainPizzas(int expectedQuantity, string expectedPizzaName)
        {
            var cartItem = app.Query(e => e.Marked(expectedPizzaName))
                .FirstOrDefault();
            Assert.IsNotNull(cartItem, "there should be a pizza <{0}> in the cart", expectedPizzaName);

            var quantityItem = app.Query(e => e.Marked(expectedPizzaName).Parent().Sibling(1).Child().Marked("QuantityLabel"))
                .FirstOrDefault();

            Assert.AreEqual(expectedQuantity.ToString(), quantityItem?.Text, "the quantity of the <{0}> pizza in the cart should be {1}", expectedPizzaName, expectedQuantity);
        }

        [Then(@"the following items should be listed")]
        public void ThenTheFollowingItemsShouldBeListed(Table expectedItemsTable)
        {
            foreach (var expectedItemRow in expectedItemsTable.Rows)
            {
                ThenTheCartShouldContainPizzas(int.Parse(expectedItemRow["quantity"]), expectedItemRow["name"]);
            }
        }

        [Then(@"the cart should be activated")]
        public void ThenTheCartShouldBeActivated()
        {
            Assert.IsTrue(IsOnCartPage, "the cart page should be visible");
        }

        [When(@"I check the cart")]
        public void WhenICheckTheCart()
        {
            if (!IsOnCartPage)
                throw new NotImplementedException("go to cart");
        }
    }
}
