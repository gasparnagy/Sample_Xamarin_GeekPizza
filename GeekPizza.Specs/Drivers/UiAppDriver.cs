using System;
using System.Linq;
using GeekPizza.Specs.Support;
using Xamarin.UITest;

namespace GeekPizza.Specs.Drivers
{
    public abstract class UiAppDriver : IAppDriver
    {
        private readonly IApp _app;

        public bool IsOnCartPage => !IsOnPizzaMenuPage && _app.Query(e => e.Marked("Cart")).Any();
        private bool IsOnPizzaMenuPage => _app.Query(e => e.Marked("Pizza Menu")).Any();

        protected UiAppDriver(Platform platform)
        {
            _app = AppInitializer.StartApp(platform);
        }

        public void EnsureItemInCart(string pizzaName, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                SelectPizza(pizzaName);
            }
        }

        public void EnsureOnCartPage()
        {
            if (!IsOnCartPage)
                throw new NotImplementedException("go to cart");
        }

        public int GetCartQuantity(string expectedPizzaName)
        {
            var cartItem = _app.Query(e => e.Marked(expectedPizzaName))
                .FirstOrDefault();

            if (cartItem == null)
                return 0;

            var quantityItem = _app.Query(e => e.Marked(expectedPizzaName).Parent().Sibling(1).Child().Marked("QuantityLabel"))
                .FirstOrDefault();

            return int.Parse(quantityItem?.Text ?? "0");
        }

        public virtual void SelectPizza(string pizzaName)
        {
            if (!IsOnPizzaMenuPage)
                _app.Back();
            _app.Tap(e => e.Marked("NameLabel").All().Text(pizzaName).Parent());
        }
    }
}