using System;

using GeekPizza1.Models;

using Xamarin.Forms;

namespace GeekPizza1.Views
{
    public partial class NewItemPage : ContentPage
    {
        public PizzaMenuItem PizzaMenuItem { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            PizzaMenuItem = new PizzaMenuItem
            {
                Name = "Item name",
                Ingredients = "This is a nice description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", PizzaMenuItem);
            await Navigation.PopToRootAsync();
        }
    }
}