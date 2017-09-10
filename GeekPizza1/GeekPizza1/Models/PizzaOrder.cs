using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekPizza1.Helpers;

namespace GeekPizza1.Models
{
    public class PizzaOrder : BaseDataObject
    {
        public ObservableRangeCollection<PizzaOrderItem> Items { get; } = new ObservableRangeCollection<PizzaOrderItem>();
    }
}
