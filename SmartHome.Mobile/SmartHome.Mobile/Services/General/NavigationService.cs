using SmartHome.Mobile.Utilities;
using SmartHome.Mobile.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using SmartHome.Mobile.Views;
using Xamarin.Forms;

namespace SmartHome.Mobile.Services.General
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task NavigateToAsync(Type viewModelType);

        Task ClearBackStack();

        Task NavigateToAsync(Type viewModelType, object parameter);

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();

        Task PopToRootAsync();
    }
    public class NavigationService : INavigationService
    {
        private readonly IDependencyResolver _dependencyResolver;

         protected Application CurrentApplication => Application.Current;

        public NavigationService(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }


        public async Task InitializeAsync()
        {
            await NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            throw new NotImplementedException();
        }

        public Task ClearBackStack()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            throw new NotImplementedException();
        }

        public Task NavigateBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);
          
            CurrentApplication.MainPage = page;

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            var index = viewModelType.Name.LastIndexOf("Model", StringComparison.Ordinal);
            var pageTypeName = viewModelType.Name.Remove(index, 5);

            var pageType = viewModelType.Assembly.GetTypes().FirstOrDefault(t => t.Name == pageTypeName);
            if (pageType == null)
            {
                throw new InvalidOperationException($"No view type found for ${viewModelType}.");
            }

            return pageType;
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = _dependencyResolver.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }
    }
}
