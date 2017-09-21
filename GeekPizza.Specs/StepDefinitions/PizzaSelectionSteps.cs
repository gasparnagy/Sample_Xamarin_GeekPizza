using System;
using System.Linq;
using System.Threading.Tasks;
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
        }

        [Given(@"I have a cart with an ""(.*)"" pizza")]
        public void GivenIHaveACartWithAnPizza(string pizzaName)
        {
            _store.AddToCart(_store.PizzaMenuItems.First(i => i.Name == pizzaName));
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

        [Then(@"the cart should be activated")]
        public void ThenTheCartShouldBeActivated()
        {
            Assert.IsInstanceOf<CartPage>(navigationStub.CurrentPage);
        }

        [Then(@"the cart should contain an ""(.*)"" pizza")]
        public void ThenTheCartShouldContainAnPizza(string expectedPizzaName)
        {
            Assert.IsTrue(_store.Order.Items.Any(i => i.Pizza.Name == expectedPizzaName));            
        }
    }
}
