using GeekPizza1.Models;

namespace GeekPizza1.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public PizzaMenuItem PizzaMenuItem { get; set; }
        public ItemDetailViewModel(PizzaMenuItem pizzaMenuItem = null)
        {
            Title = pizzaMenuItem.Name;
            PizzaMenuItem = pizzaMenuItem;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}