using SmartHome.Mobile.Models;
using System.Collections.Generic;

namespace SmartHome.Mobile.ViewModels
{
    public class LightListViewModel : ViewModelBase
    {
        public List<Light> lights { get; set; }

        public LightListViewModel()
        {

        }


        private void OnLightSelected(Light light)
        {
            //TODO: navigate //TODO: send movie to MovieDetailsViewModel }
        }

    }
}

   
