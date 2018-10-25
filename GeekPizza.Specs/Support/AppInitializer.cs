using System;
using System.IO;
using Xamarin.UITest;

namespace GeekPizza.Specs.Support
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
            var androidProjectFolder = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "GeekPizza", "GeekPizza.Android");
            var apkPath = Path.Combine(androidProjectFolder, "bin", "Release", apkFileName);
            if (!File.Exists(apkPath))
                throw new InvalidOperationException($"Unable to find APK at '{apkPath}'");
            return apkPath;
        }
    }
}

