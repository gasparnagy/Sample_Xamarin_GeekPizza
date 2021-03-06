﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using GeekPizza.Helpers;
using GeekPizza.Models;
using GeekPizza.Services;
using GeekPizza.Views;
using Xamarin.Forms;

namespace GeekPizza.ViewModels
{
    public class PizzaMenuViewModel : BaseViewModel
    {
        private readonly IStore _store;
        public ObservableRangeCollection<PizzaMenuItem> Items { get; }
        public ICommand InitializeStoreCommand { get; }
        public ICommand ItemTappedCommand { get; }
        public ICommand ShowCartCommand { get; }

        public PizzaMenuViewModel(IStore store)
        {
            _store = store;
            Title = "Pizza Menu";
            Items = store.PizzaMenuItems;
            InitializeStoreCommand = new Command(async () => await InitializeStore());
            ItemTappedCommand = new Command(async (item) =>
            {
                _store.AddToCart((PizzaMenuItem)item);
                await NavigateToCartPage();
            });
            ShowCartCommand = new Command(async () =>
            {
                await NavigateToCartPage();
            });

            InitializeStoreCommand.Execute(null);
        }

        private async Task NavigateToCartPage()
        {
            await Navigation.PushAsync(new CartPage(new CartViewModel(_store)));
        }

        async Task InitializeStore()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _store.InitializeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}