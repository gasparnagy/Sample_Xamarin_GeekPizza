using System;
using System.Linq;
using GeekPizza.Helpers;

namespace GeekPizza.Models
{
    public class PizzaOrder : BaseDataObject
    {
        public ObservableRangeCollection<PizzaOrderItem> Items { get; } = new ObservableRangeCollection<PizzaOrderItem>();

        public Address DeliveryAddress { get; } = new Address();
    }
}
