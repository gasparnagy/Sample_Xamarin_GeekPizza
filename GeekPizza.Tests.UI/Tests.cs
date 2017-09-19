using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GeekPizza.Tests.UI
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
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void Test1()
        {
            app.Tap(e => e.Marked("NameLabel").All().Text("Chris Matts' GTW").Parent());
            app.Back();
            //app.Tap(e => e.Marked("NameLabel").All().Text("Uncle Bob's FitNesse").Parent());
            //app.Back();
            app.Tap(e => e.Marked("NameLabel").All().Text("Aslak Hellesøy's Cucumber").Parent());
            app.Back();
            app.Tap(e => e.Marked("NameLabel").All().Text("Aslak Hellesøy's Cucumber").Parent());
            var text = app.Query(e =>
                    e.Marked("NameLabel").All().Text("Aslak Hellesøy's Cucumber").Parent().All().Marked("QuantityLabel"))
                .First().Text;
            Assert.AreEqual("2", text);
        }
    }
}

