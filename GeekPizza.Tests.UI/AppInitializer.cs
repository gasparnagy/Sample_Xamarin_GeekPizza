using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GeekPizza.Tests.UI
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                Console.WriteLine(Environment.CurrentDirectory);
                return ConfigureApp
                    .Android
                    .ApkFile(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", @"GeekPizza1\GeekPizza1.Android\bin\Release\com.companyname.GeekPizza1.apk"))
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

