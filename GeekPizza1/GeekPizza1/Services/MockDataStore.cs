using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GeekPizza1.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(GeekPizza1.Services.MockDataStore))]
namespace GeekPizza1.Services
{
    public class MockDataStore : IDataStore<PizzaMenuItem>
    {
        bool isInitialized;
        List<PizzaMenuItem> items;

        public async Task<bool> AddItemAsync(PizzaMenuItem pizzaMenuItem)
        {
            await InitializeAsync();

            items.Add(pizzaMenuItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PizzaMenuItem pizzaMenuItem)
        {
            await InitializeAsync();

            var _item = items.Where((PizzaMenuItem arg) => arg.Id == pizzaMenuItem.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(pizzaMenuItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(PizzaMenuItem pizzaMenuItem)
        {
            await InitializeAsync();

            var _item = items.Where((PizzaMenuItem arg) => arg.Id == pizzaMenuItem.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<PizzaMenuItem> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<PizzaMenuItem>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<PizzaMenuItem>();
            var _items = new List<PizzaMenuItem>
            {
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "XAslak Hellesøy's Cucumber", Ingredients="Cucumber, Gherkin, Pickles"},
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "XUncle Bob's FitNesse", Ingredients="Chicken, Low cal cheese"},
                new PizzaMenuItem { Id = Guid.NewGuid().ToString(), Name = "XChris Matts' GTW", Ingredients="Garlic, Wasabi, Tomato"},
            };

            foreach (PizzaMenuItem item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
