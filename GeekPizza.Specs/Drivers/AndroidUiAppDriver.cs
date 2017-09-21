using Xamarin.UITest;

namespace GeekPizza.Specs.Drivers
{
    public class AndroidUiAppDriver : UiAppDriver
    {
        public AndroidUiAppDriver() : base(Platform.Android)
        {
        }
    }
}