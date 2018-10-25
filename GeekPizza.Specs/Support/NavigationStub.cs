using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekPizza.ViewModels;
using Xamarin.Forms;

namespace GeekPizza.Specs.Support
{
    public class NavigationStub : INavigation
    {
        private readonly Stack<Page> _navigationStack = new Stack<Page>();
        private readonly Stack<Page> _modalStack = new Stack<Page>();

        public void InsertPageBefore(Page page, Page before)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync(bool animated)
        {
            return PopAsync();
        }

        public Task<Page> PopModalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return PopModalAsync();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync(bool animated)
        {
            return PopToRootAsync();
        }

        public Task PushAsync(Page page)
        {
            _navigationStack.Push(page);
            return Task.FromResult<object>(null);
        }

        public Task PushAsync(Page page, bool animated)
        {
            return PushAsync(page);
        }

        public Task PushModalAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return PushModalAsync(page);
        }

        public void RemovePage(Page page)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Page> ModalStack => new ReadOnlyCollection<Page>(_modalStack.ToList());
        public IReadOnlyList<Page> NavigationStack => new ReadOnlyCollection<Page>(_navigationStack.ToList());

        public ContentPage CurrentPage => (ContentPage) _navigationStack.Peek();
        public BaseViewModel CurrentViewModel => (BaseViewModel) CurrentPage.BindingContext;

    }
}
