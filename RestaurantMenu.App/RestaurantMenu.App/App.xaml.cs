using RestaurantMenu.App.Constants;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMenu.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //
            if (!Application.Current.Properties.ContainsKey(AppConstants.RESTAURANT_NAME_PROP))
            {
                Application.Current.Properties[AppConstants.RESTAURANT_NAME_PROP] = "";
            }

            if (!Application.Current.Properties.ContainsKey(AppConstants.APP_PASSWORD_PROP))
            {
                Application.Current.Properties[AppConstants.APP_PASSWORD_PROP] = "1";
            }

            ///

            var main = new NavigationPage(new MainPage());
            //main.FlowDirection = FlowDirection.RightToLeft;
            MainPage = main;

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
