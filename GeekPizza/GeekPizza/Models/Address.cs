using GeekPizza.Helpers;

namespace GeekPizza.Models
{
    public class Address : ObservableObject
    {
        string _streetAddress = string.Empty;
        public string StreetAddress
        {
            get => _streetAddress;
            set => SetProperty(ref _streetAddress, value);
        }

        string _city = string.Empty;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        string _zip = string.Empty;
        public string Zip
        {
            get => _zip;
            set => SetProperty(ref _zip, value);
        }
    }
}
