using GeekPizza.Helpers;
using Xamarin.Forms;

namespace GeekPizza.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public INavigation Navigation { get; set; }

        bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string _title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}

