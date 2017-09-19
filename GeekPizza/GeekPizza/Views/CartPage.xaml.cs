using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekPizza.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeekPizza.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{
		public CartPage(CartViewModel viewModel)
		{
			InitializeComponent();

		    BindingContext = viewModel;
		}
	}
}