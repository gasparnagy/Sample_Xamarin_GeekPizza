using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(GeekPizza.Services.Testing.TestBackdoor))]
namespace GeekPizza.Services.Testing
{
    public interface ITestBackdoor
    {
        void EnsureItemInCart(string pizzaName, int quantity);
        void ResetCart();
    }

    public class TestBackdoor : ITestBackdoor
    {
        private readonly IStore _store;

        public TestBackdoor() : this(DependencyService.Get<IStore>())
        {
        }

        public TestBackdoor(IStore store)
        {
            _store = store;
        }

        public void EnsureItemInCart(string pizzaName, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _store.AddToCart(_store.PizzaMenuItems.First(item => item.Name == pizzaName));
        }

        public void ResetCart()
        {
            _store.ClearOrder();
        }
    }
}
