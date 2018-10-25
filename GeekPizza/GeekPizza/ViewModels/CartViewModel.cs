using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekPizza.Helpers;
using GeekPizza.Models;
using GeekPizza.Services;
using GeekPizza.Views;
using Xamarin.Forms;

namespace GeekPizza.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableRangeCollection<PizzaOrderItem> Items { get; set; }
        public ICommand OrderCommand { get; }

        public CartViewModel(Store store)
        {
            Title = "Cart";
            Items = store.Order.Items;
            OrderCommand = new Command(async () =>
            {
                await Navigation.PushAsync(new EnterAddressPage(new EnterAddressViewModel(store)));
            });
        }
    }
}
