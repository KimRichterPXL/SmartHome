
namespace SmartHome.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public LightListViewModel LightListView { get; set; }
        public MainViewModel()
        {
            LightListView= new LightListViewModel();
        }

      
    }
}
