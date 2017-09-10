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
            var defaultDeliveryAddress = await _restaurant.GetDefaultDeliveryAddressAsync();
            if (defaultDeliveryAddress != null)
            {
                Order.DeliveryAddress.StreetAddress = defaultDeliveryAddress.StreetAddress;
                Order.DeliveryAddress.City = defaultDeliveryAddress.City;
                Order.DeliveryAddress.Zip = defaultDeliveryAddress.Zip;
            }
            _isInitialized = true;
        }

        public void AddToCart(PizzaMenuItem item)
        {
            Order.Items.Add(new PizzaOrderItem(item, 1));
        }
    }
}
