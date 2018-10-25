using System;
using System.Linq;
using System.Threading.Tasks;
using GeekPizza.Helpers;
using GeekPizza.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(GeekPizza.Services.Store))]
namespace GeekPizza.Services
{
    public class Store : IStore
    {
        private readonly IRestaurant _restaurant;
        private bool _isInitialized = false;
        public PizzaOrder Order { get; }
        public ObservableRangeCollection<PizzaMenuItem> PizzaMenuItems { get; }

        public Store() : this(DependencyService.Get<IRestaurant>())
        {
        }

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

        public void ClearOrder()
        {
            Order.Items.Clear();
        }

        public void AddToCart(PizzaMenuItem item)
        {
            var existingItem = Order.Items.FirstOrDefault(i => i.Pizza.Name == item.Name);
            if (existingItem == null)
                Order.Items.Add(new PizzaOrderItem(item, 1));
            else
                existingItem.Quantity++;
        }
    }
}
