using System;
using System.Linq;
using GeekPizza.Specs.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace GeekPizza.Specs.StepDefinitions
{
    [Binding]
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
        
        [When(@"I select the ""(.*)"" pizza")]
        public void WhenISelectThePizza(string pizzaName)
        {
            if (!app.Query(e => e.Marked("Pizza Menu")).Any())
                app.Back();
            app.Tap(e => e.Marked("NameLabel").All().Text(pizzaName).Parent());
        }

        [Then(@"the cart should contain an ""(.*)"" pizza")]
        public void ThenTheCartShouldContainAnPizza(string expectedPizzaName)
        {
            var expectedQuantity = 1;
            var cartItem = app.Query(e => e.Marked(expectedPizzaName))
                .FirstOrDefault();
            Assert.IsNotNull(cartItem, "there should be a pizza <{0}> in the cart", expectedPizzaName);

            var quantityItem = app.Query(e => e.Marked(expectedPizzaName).Parent().Sibling(1).Child().Marked("QuantityLabel"))
                .FirstOrDefault();

            Assert.AreEqual(expectedQuantity.ToString(), quantityItem?.Text, "the quantity of the <{0}> pizza in the cart should be {1}", expectedPizzaName, expectedQuantity);
        }
    }
}
