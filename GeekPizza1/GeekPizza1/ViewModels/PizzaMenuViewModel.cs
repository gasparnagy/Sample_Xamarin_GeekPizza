using System;
using System.Diagnostics;
using System.Threading.Tasks;

using GeekPizza1.Helpers;
using GeekPizza1.Models;
using GeekPizza1.Services;
using GeekPizza1.Views;

using Xamarin.Forms;

namespace GeekPizza1.ViewModels
{
    public class PizzaMenuViewModel : BaseViewModel
    {
        private readonly Store _store;
        public ObservableRangeCollection<PizzaMenuItem> Items { get; set; }
        public Command InitializeStoreCommand { get; set; }

        public PizzaMenuViewModel(Store store)
        {
            _store = store;
            Title = "Pizza Menu";
            Items = store.PizzaMenuItems;
            InitializeStoreCommand = new Command(async () => await InitializeStore());

            MessagingCenter.Subscribe<NewItemPage, PizzaMenuItem>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as PizzaMenuItem;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
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