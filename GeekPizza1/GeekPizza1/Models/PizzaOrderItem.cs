using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekPizza1.Models
{
    public class PizzaOrderItem
    {
        public PizzaMenuItem Pizza { get; set; }
        public int Quantity { get; set; }
    }
}
