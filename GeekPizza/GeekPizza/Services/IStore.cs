using System.Threading.Tasks;
using GeekPizza.Helpers;
using GeekPizza.Models;

namespace GeekPizza.Services
{
    public interface IStore
    {
        PizzaOrder Order { get; }
        ObservableRangeCollection<PizzaMenuItem> PizzaMenuItems { get; }
        Task InitializeAsync();
        void ClearOrder();
        void AddToCart(PizzaMenuItem item);
    }
}