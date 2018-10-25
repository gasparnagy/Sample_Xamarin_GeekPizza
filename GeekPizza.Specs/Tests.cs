using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GeekPizza.Specs
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void MargheritaIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Margherita"));
            app.Screenshot("Menu screen.");

            Assert.IsTrue(results.Any());
        }
    }
}
