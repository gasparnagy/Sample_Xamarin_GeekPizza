using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekPizza1.Helpers;
using GeekPizza1.Models;
using GeekPizza1.Services;

namespace GeekPizza1.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableRangeCollection<PizzaOrderItem> Items { get; set; }

        public CartViewModel(Store store)
        {
            Items = store.Order.Items;
        }
    }
}
