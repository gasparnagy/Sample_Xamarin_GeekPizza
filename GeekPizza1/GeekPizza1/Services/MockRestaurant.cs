using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekPizza1.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(GeekPizza1.Services.MockRestaurant))]
namespace GeekPizza1.Services
{
    public class MockRestaurant : IRestaurant
    {
        private bool _isInitialized;
        private List<PizzaMenuItem> _menuItems;

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            _menuItems = new List<PizzaMenuItem>
            {
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Aslak Hellesøy's Cucumber", Ingredients="Cucumber, Gherkin, Pickles"},
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Uncle Bob's FitNesse", Ingredients="Chicken, Low cal cheese"},
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Chris Matts' GTW", Ingredients="Garlic, Wasabi, Tomato"},
            };

            _isInitialized = true;
        }

        public async Task<IEnumerable<PizzaMenuItem>> GetMenuItemsAsync()
        {
            await InitializeAsync();

            return await Task.FromResult(_menuItems);
        }

        public async Task<Address> GetDefaultDeliveryAddressAsync()
        {
            await InitializeAsync();

            return await Task.FromResult(new Address
            {
                StreetAddress = "One Marina Boulevard",
                City = "Singapore",
                Zip = "018989"
            });
        }
    }
}