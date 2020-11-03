
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHome.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmartHomeNavigationPage : NavigationPage
    {
        public SmartHomeNavigationPage()
        {
            InitializeComponent();
        }

        public SmartHomeNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}