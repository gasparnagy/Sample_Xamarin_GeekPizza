using System;
using System.Linq;
using GeekPizza.Services;
using GeekPizza.Specs.Support;
using GeekPizza.ViewModels;
using GeekPizza.Views;

namespace GeekPizza.Specs.Drivers
{
    public class ViewModelAppDriver : IAppDriver
    {
        private readonly Store _store = new Store(new MockRestaurant());
        private readonly NavigationStub navigationStub = new NavigationStub();

        private CartViewModel cartViewModel;

        public ViewModelAppDriver()
        {
            ContentBasePage.IsTesting = true;
            _store.InitializeAsync().Wait();
        }

        public void ResetApp()
        {
            _store.ClearOrder();
        }

        public void EnsureItemInCart(string pizzaName, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _store.AddToCart(_store.PizzaMenuItems.First(item => item.Name == pizzaName));
        }

        public void SelectPizza(string pizzaName)
        {
            var viewModel = new PizzaMenuViewModel(_store)
            {
                Navigation = navigationStub
            };

            var pizzaItem = viewModel.Items.FirstOrDefault(i => i.Name == pizzaName);
            viewModel.ItemTappedCommand.Execute(pizzaItem);
        }

        public void EnsureOnCartPage()
        {
            if (cartViewModel != null)
                return;
            cartViewModel = new CartViewModel(_store)
            {
                Navigation = navigationStub
            };
        }

        public bool IsOnCartPage => navigationStub.CurrentPage is CartPage;

        public int GetCartQuantity(string expectedPizzaName)
        {
            var cartItem = cartViewModel.Items.FirstOrDefault(i => i.Pizza.Name == expectedPizzaName);
            return cartItem?.Quantity ?? 0;
        }
    }
}
