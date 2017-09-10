using System;
using System.Diagnostics;
using System.Threading.Tasks;

using GeekPizza1.Helpers;
using GeekPizza1.Models;
using GeekPizza1.Views;

using Xamarin.Forms;

namespace GeekPizza1.ViewModels
{
    public class PizzaMenuViewModel : BaseViewModel
    {
        public ObservableRangeCollection<PizzaMenuItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PizzaMenuViewModel()
        {
            Title = "Pizza Menu";
            Items = new ObservableRangeCollection<PizzaMenuItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, PizzaMenuItem>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as PizzaMenuItem;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
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