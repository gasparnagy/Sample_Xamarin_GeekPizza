using System;
using GeekPizza1.Models;
using GeekPizza1.Services;
using GeekPizza1.ViewModels;
using Xamarin.Forms;

namespace GeekPizza1.Views
{
    public partial class PizzaMenuPage : ContentPage
    {
        private readonly PizzaMenuViewModel _viewModel;

        public PizzaMenuPage(Store store)
        {
            InitializeComponent();

            BindingContext = _viewModel = new PizzaMenuViewModel(store);
        }

        private void PizzaMenuItem_Tapped(object sender, ItemTappedEventArgs args)
        {
            var item = args.Item as PizzaMenuItem;
            if (item == null)
                return;

            _viewModel.ItemTappedCommand.Execute(item);

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }
    }
}
