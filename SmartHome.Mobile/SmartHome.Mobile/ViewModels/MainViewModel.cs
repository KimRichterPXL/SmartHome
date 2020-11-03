
using SmartHome.Mobile.Services.General;
using System.Threading.Tasks;

namespace SmartHome.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel _menuViewModel;

        public MainViewModel(
            INavigationService navigationService,
            MenuViewModel menuViewModel):base(navigationService)
        {
            _menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<LightDetailViewModel>()
            );
        }
    }
}
