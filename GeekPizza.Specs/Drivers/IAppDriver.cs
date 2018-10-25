namespace GeekPizza.Specs.Drivers
{
    public interface IAppDriver
    {
        bool IsOnCartPage { get; }

        void ResetApp();
        void EnsureItemInCart(string pizzaName, int quantity);
        void EnsureOnCartPage();
        int GetCartQuantity(string expectedPizzaName);
        void SelectPizza(string pizzaName);
    }
}