using GeekPizza1.Helpers;
using GeekPizza1.Models;
using GeekPizza1.Services;

using Xamarin.Forms;

namespace GeekPizza1.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public INavigation Navigation { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

