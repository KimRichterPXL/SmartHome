using SmartHome.Mobile.Models;
using SmartHome.Mobile.Services;
using SmartHome.Mobile.Services.General;
using SmartHome.Mobile.Utilities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHome.Mobile.ViewModels
{
    public class LightListViewModel : ViewModelBase
    {
        private readonly ILightDataService _lightDataService;
        private ObservableCollection<Light> _lights;

        public LightListViewModel(
            INavigationService navigationService,
            ILightDataService lightDataService) : base(navigationService)
        {
            _lightDataService = lightDataService;
        }

        public ICommand LightTappedCommand => new Command<Light>(OnLightTapped);

        public ObservableCollection<Light> Pies
        {
            get => _lights;
            set
            {
                _lights = value;
                OnPropertyChanged();
            }
        }

        private void OnLightTapped(Light selectedLight)
        {
            _navigationService.NavigateToAsync<LightDetailViewModel>(selectedLight);
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            Pies = (await _lightDataService.GetAllLightsAsync()).ToObservableCollection();

            IsBusy = false;
        }

    }
}

   
