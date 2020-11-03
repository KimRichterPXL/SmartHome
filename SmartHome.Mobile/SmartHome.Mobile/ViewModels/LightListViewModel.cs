using SmartHome.Mobile.Models;
using SmartHome.Mobile.Services.General;
using System.Collections.Generic;

namespace SmartHome.Mobile.ViewModels
{
    public class LightListViewModel : ViewModelBase
    {
        public List<Light> lights { get; set; }

        public LightListViewModel(INavigationService navigationService) : base(navigationService)
        {
        }




        private void OnLightSelected(Light light)
        {
            //TODO: navigate //TODO: send movie to MovieDetailsViewModel }
        }

    }
}

   
