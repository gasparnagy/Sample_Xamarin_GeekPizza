using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekPizza.Models
{
    public class PizzaOrderItem
    {
        public PizzaOrderItem(PizzaMenuItem pizza, int quantity)
        {
            Pizza = pizza;
            Quantity = quantity;
        }

        public PizzaMenuItem Pizza { get; set; }
        public int Quantity { get; set; }
    }
}
