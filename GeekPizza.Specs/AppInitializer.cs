using System;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GeekPizza.Specs
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(GetApkPath())
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }

        private static string GetApkPath()
        {
            const string apkFileName = "eu.specsolutions.demo.GeekPizza.apk";
            Console.WriteLine(Environment.CurrentDirectory);
            var androidProjectFolder = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "GeekPizza", "GeekPizza.Android");
            var apkPath = Path.Combine(androidProjectFolder, "bin", "Release", apkFileName);
            return apkPath;
        }
    }
}