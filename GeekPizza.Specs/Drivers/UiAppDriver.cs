using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GeekPizza.Services.Testing;
using GeekPizza.Specs.Support;
using NUnit.Framework;
using Xamarin.UITest;

namespace GeekPizza.Specs.Drivers
{
    public abstract class UiAppDriver : IAppDriver
    {
        private readonly Platform _platform;
        private static IApp _app;

        public bool IsOnCartPage => !IsOnPizzaMenuPage && _app.Query(e => e.Marked("Cart")).Any();
        private bool IsOnPizzaMenuPage => _app.Query(e => e.Marked("Pizza Menu")).Any();

        protected UiAppDriver(Platform platform)
        {
            _platform = platform;
        }

        public void CallBackdoor(Expression<Action<ITestBackdoor>> backdoorAction)
        {
            var methodCallExpression = (MethodCallExpression) backdoorAction.Body;
            string methodName = methodCallExpression.Method.Name;
            string args = string.Join(",", methodCallExpression.Arguments
                .Select(paramExpr => Expression.Lambda(paramExpr).Compile().DynamicInvoke().ToString()));
            _app.Invoke("CallBackdoor", new object[] { methodName, args });
        }

        public void ResetApp()
        {
            if (_app == null)
                _app = AppInitializer.StartApp(_platform);
            else
            {
                // navigate back to home page (in real app we need a smarter way)
                if (IsOnCartPage)
                    _app.Back();
                // reset state
                CallBackdoor(t => t.ResetCart());
            }
        }

        public void EnsureItemInCart(string pizzaName, int quantity)
        {
            CallBackdoor(t => t.EnsureItemInCart(pizzaName, quantity));
            //for (int i = 0; i < quantity; i++)
            //    SelectPizza(pizzaName);
        }

        public void EnsureOnCartPage()
        {
            if (!IsOnCartPage)
                _app.Tap("Show Cart");
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

            // the action is performed completely when the app is on the cart page
            WaitForCartPage();
        }

        private void WaitForCartPage()
        {
            Wait.For(() => Assert.IsTrue(IsOnCartPage));
        }
    }
}