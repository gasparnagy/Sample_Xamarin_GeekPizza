using System;

using GeekPizza1.Models;
using GeekPizza1.ViewModels;

using Xamarin.Forms;

namespace GeekPizza1.Views
{
    public partial class PizzaMenuPage : ContentPage
    {
        PizzaMenuViewModel viewModel;

        public PizzaMenuPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PizzaMenuViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PizzaMenuItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
