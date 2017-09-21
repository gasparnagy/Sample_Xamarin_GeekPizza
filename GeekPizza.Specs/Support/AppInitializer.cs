﻿using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;

namespace GeekPizza.Specs.Support
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
                    .ApkFile(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", @"GeekPizza\GeekPizza.Android\bin\Release\com.companyname.GeekPizza.apk"))
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}
