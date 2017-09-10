using System;
using System.Linq;
using System.Threading.Tasks;
using GeekPizza1.Helpers;
using GeekPizza1.Models;

namespace GeekPizza1.Services
{
    public class Store
    {
        private readonly IRestaurant _restaurant;
        private bool _isInitialized = false;
        public PizzaOrder Order { get; }
        public ObservableRangeCollection<PizzaMenuItem> PizzaMenuItems { get; }

        public Store(IRestaurant restaurant)
        {
            _restaurant = restaurant;
            Order = new PizzaOrder();
            PizzaMenuItems = new ObservableRangeCollection<PizzaMenuItem>();
        }

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            PizzaMenuItems.AddRange(await _restaurant.GetMenuItemsAsync());
            _isInitialized = true;
        }
    }
}
