using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekPizza.Models;
using GeekPizza.Services;
using GeekPizza.Views;
using Xamarin.Forms;

namespace GeekPizza.ViewModels
{
    public class EnterAddressViewModel : BaseViewModel
    {
        public Address DeliveryAddress { get; }
        public ICommand PayCommand { get; }

        public EnterAddressViewModel(Store store)
        {
            Title = "Delivery Address";
            DeliveryAddress = store.Order.DeliveryAddress;
            PayCommand = new Command(async () =>
            {
                store.ClearOrder();
                await Navigation.PushAsync(new ThankYouPage(new ThankYouViewModel(store)));
            });
        }
    }
}
