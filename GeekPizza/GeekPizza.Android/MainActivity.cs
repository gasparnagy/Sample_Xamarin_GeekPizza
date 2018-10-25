using System;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GeekPizza.Services.Testing;
using Java.Interop;

namespace GeekPizza.Droid
{
    [Activity(Label = "GeekPizza", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [Export]
        public void CallBackdoor(string methodName, string args)
        {
            var testBackdoor = Xamarin.Forms.DependencyService.Get<ITestBackdoor>();
            var method = typeof(ITestBackdoor).GetMethod(methodName);
            if (method == null)
                return;
            var parameterInfos = method.GetParameters();
            object[] methodArgs = null;
            if (!string.IsNullOrEmpty(args))
                methodArgs = args.Split(',').Select((a, i) => Convert.ChangeType(a, parameterInfos[i].ParameterType)).ToArray();
            method.Invoke(testBackdoor, methodArgs);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}