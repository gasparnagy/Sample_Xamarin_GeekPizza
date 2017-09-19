using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekPizza.Models;
using GeekPizza.Services;
using Xamarin.Forms;

namespace GeekPizza.ViewModels
{
    public class ThankYouViewModel : BaseViewModel
    {
        public PizzaOrder Order { get; }
        public ICommand ShowMenuCommand { get; }

        public string OrderDetails =>
            string.Join(Environment.NewLine, Order.Items.Select(i => $"{i.Pizza.Name} -- {i.Quantity}pcs"));

        public ThankYouViewModel(Store store)
        {
            Title = "Thank you!";
            Order = store.Order;
            ShowMenuCommand = new Command(async () =>
            {
                await Navigation.PopToRootAsync();
            });
        }
    }
}
