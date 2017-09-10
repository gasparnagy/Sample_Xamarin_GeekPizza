using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekPizza1.Models;
using GeekPizza1.Services;

namespace GeekPizza1.ViewModels
{
    public class EnterAddressViewModel : BaseViewModel
    {
        private readonly Store _store;

        public Address DeliveryAddress { get; }

        public EnterAddressViewModel(Store store)
        {
            _store = store;
            DeliveryAddress = store.Order.DeliveryAddress;
        }
    }
}
