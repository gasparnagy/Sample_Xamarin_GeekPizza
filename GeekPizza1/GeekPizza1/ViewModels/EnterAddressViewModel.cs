﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekPizza1.Models;
using GeekPizza1.Services;
using GeekPizza1.Views;
using Xamarin.Forms;

namespace GeekPizza1.ViewModels
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
                await Navigation.PushAsync(new ThankYouPage(new ThankYouViewModel(store)));
            });
        }
    }
}
