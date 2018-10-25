using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekPizza.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(GeekPizza.Services.MockRestaurant))]
namespace GeekPizza.Services
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
                //new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Gojko Adzic's 50Q", Ingredients="Quail, Quinoa, quark, quince & 46 others"},
                //new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Uncle Bob's FitNesse", Ingredients="Chicken, Low cal cheese"},
                //new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Aslak Hellesøy's Cucumber", Ingredients="Cucumber, Gherkin, Pickles"},
                //new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Chris Matts' GWT", Ingredients="Garlic, Wasabi, Tomato"},
                //new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Dan North's b-hake", Ingredients="Hake/cod/haddock, mushy peas, chips"},
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Margherita", Ingredients = "tomato slices, oregano, mozzarella", Calories = 1920 },
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Fitness", Ingredients = "sweetcorn, broccoli, feta cheese, mozzarella", Calories = 1340 },
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "BBQ", Ingredients = "BBQ sauce, bacon, chicken breast strips, onions", Calories = 1580 },
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Mexican", Ingredients = "taco sauce, bacon, beans, sweetcorn, mozzarella", Calories = 2340 },
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "Quattro formaggi", Ingredients = "blue cheese, parmesan, smoked mozzarella, mozzarella", Calories = 2150 }
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