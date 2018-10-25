using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeekPizza.Views
{
    public abstract class ContentBasePage : ContentPage
    {
        public static bool IsTesting { get; set; } = false;

        private object _bindingContextForTest;
        public new object BindingContext
        {
            get => IsTesting ? _bindingContextForTest : base.BindingContext;
            set
            {
                if (IsTesting)
                    _bindingContextForTest = value;
                else
                    base.BindingContext = value;
            }

        }
    }
}
