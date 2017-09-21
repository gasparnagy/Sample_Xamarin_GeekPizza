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
            app.Tap(e => e.Marked("NameLabel").All().Text(pizzaName).Parent());
        }

        [Then(@"the cart should contain an ""(.*)"" pizza")]
        public void ThenTheCartShouldContainAnPizza(string expectedPizzaName)
        {
            var cartItem = app.Query(e => e.Marked("NameLabel").All().Text(expectedPizzaName))
                .FirstOrDefault();
            Assert.IsNotNull(cartItem, "there should be a pizza <{0}> in the cart", expectedPizzaName);
        }
    }
}
