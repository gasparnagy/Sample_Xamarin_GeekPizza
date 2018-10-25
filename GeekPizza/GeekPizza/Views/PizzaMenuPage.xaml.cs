using System;
using GeekPizza.Models;
using GeekPizza.Services;
using GeekPizza.ViewModels;
using Xamarin.Forms;

namespace GeekPizza.Views
{
    public partial class PizzaMenuPage : ContentPage
    {
        private readonly PizzaMenuViewModel _viewModel;

        public PizzaMenuPage(IStore store)
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
