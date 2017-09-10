using GeekPizza1.Services;
using GeekPizza1.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GeekPizza1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            var restaurant = DependencyService.Get<IRestaurant>();
            var store = new Store(restaurant);

            Current.MainPage = new NavigationPage(new PizzaMenuPage(store));
        }
    }
}
