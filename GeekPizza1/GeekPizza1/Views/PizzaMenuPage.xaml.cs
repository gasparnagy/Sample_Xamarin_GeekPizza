using System;

using GeekPizza1.Models;
using GeekPizza1.Services;
using GeekPizza1.ViewModels;

using Xamarin.Forms;

namespace GeekPizza1.Views
{
    public partial class PizzaMenuPage : ContentPage
    {
        private readonly Store _store;
        PizzaMenuViewModel viewModel;

        public PizzaMenuPage(Store store)
        {
            _store = store;
            InitializeComponent();

            BindingContext = viewModel = new PizzaMenuViewModel(store);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PizzaMenuItem;
            if (item == null)
                return;

            _store.AddToCart(item);

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            await Navigation.PushAsync(new CartPage(new CartViewModel(_store)));

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
                viewModel.InitializeStoreCommand.Execute(null);
        }
    }
}
