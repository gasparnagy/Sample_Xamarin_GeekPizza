using System;
using System.Linq;
using GeekPizza1.Helpers;

namespace GeekPizza1.Models
{
    public class PizzaOrder : BaseDataObject
    {
        public ObservableRangeCollection<PizzaOrderItem> Items { get; } = new ObservableRangeCollection<PizzaOrderItem>();

        public Address DeliveryAddress { get; } = new Address();
    }
}
