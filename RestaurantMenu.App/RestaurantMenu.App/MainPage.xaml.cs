using RestaurantMenu.App.Constants;
using RestaurantMenu.App.Pages;
using RestaurantMenu.App.Repositories;
using RestaurantMenu.App.Services;
using RestaurantMenu.App.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace RestaurantMenu.App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSwipePagingEnabled(false);
            On<Android>().SetIsSmoothScrollEnabled(false);



        }

        private async void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {

            var tabbedPage = (Xamarin.Forms.TabbedPage)sender;
            if (tabbedPage.CurrentPage == editPage)
            {
                string result = "";
                 result = await DisplayPromptAsync("", "لطفا رمز عبور را وارد کنید\nرمز پیشفرض:1", accept: "ورود", cancel: "لغو", placeholder: "رمز عبور...", maxLength: 8, keyboard: Keyboard.Plain,initialValue:"");
                if (result == null)
                {
                    tabbedPage.CurrentPage = menuPage;
                    return;
                }
                result = result.ToEnglishNumber();
                string appPassword = Xamarin.Forms.Application.Current.Properties[AppConstants.APP_PASSWORD_PROP].ToString();
                if (result !=appPassword )
                {
                    await DisplayAlert("", "رمز عبور صحیح نمیباشد", "باش");
                    tabbedPage.CurrentPage = menuPage;
                    return;
                }
            }

        }
    }
}
