﻿using SmartHome.Mobile.Enumerations;
using SmartHome.Mobile.Models;
using SmartHome.Mobile.Services.General;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHome.Mobile.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MainMenuItem> _menuItems;

        public MenuViewModel(INavigationService navigationService) : base(navigationService)
        {
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public string WelcomeText => "Hello Kim" ;

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                //_settingsService.UserIdSetting = null;
                //_settingsService.UserNameSetting = null;
                _navigationService.ClearBackStack();
            }

            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }


        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Home",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.Home
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Lights",
                ViewModelToLoad = typeof(LightListViewModel),
                MenuItemType = MenuItemType.Light
            });


            //MenuItems.Add(new MainMenuItem
            //{
            //    MenuText = "Log out",
            //    ViewModelToLoad = typeof(LoginViewModel),
            //    MenuItemType = MenuItemType.Logout
            //});
        }
    }
}
