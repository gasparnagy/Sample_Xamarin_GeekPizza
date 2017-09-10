using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekPizza1.Helpers;
using GeekPizza1.Models;
using GeekPizza1.Services;
using GeekPizza1.Views;
using Xamarin.Forms;

namespace GeekPizza1.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableRangeCollection<PizzaOrderItem> Items { get; set; }
        public ICommand OrderCommand { get; }

        public CartViewModel(Store store)
        {
            Items = store.Order.Items;
            OrderCommand = new Command(async () =>
            {
                await Navigation.PushAsync(new EnterAddressPage(new EnterAddressViewModel(store)));
            });
        }
    }
}
