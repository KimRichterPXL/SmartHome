using SmartHome.Mobile.Services.General;
using SmartHome.Mobile.Utilities;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHome.Mobile
{
    public partial class App : Application
    {
        private readonly IDependencyResolver _dependencyResolver;
        public App()
        {
            _dependencyResolver = AppContainer.Instance;

            InitializeComponent();

            InitializeNavigation();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = _dependencyResolver.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}


