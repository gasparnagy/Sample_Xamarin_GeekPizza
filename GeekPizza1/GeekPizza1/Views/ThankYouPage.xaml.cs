using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekPizza1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeekPizza1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThankYouPage : ContentPage
	{
		public ThankYouPage(ThankYouViewModel viewModel)
		{
			InitializeComponent();

		    BindingContext = viewModel;
		}
	}
}