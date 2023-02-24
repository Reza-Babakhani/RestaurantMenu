using RestaurantMenu.App.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMenu.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey(AppConstants.RESTAURANT_NAME_PROP))
            {
                txtName.Text = Application.Current.Properties[AppConstants.RESTAURANT_NAME_PROP].ToString();

            }
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }



        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (Validation())
            {
                Application.Current.Properties[AppConstants.RESTAURANT_NAME_PROP] = txtName.Text;
                
                //Change Password
                if (!String.IsNullOrEmpty(txtPassword.Text))
                {
                    if (txtOldPassword.Text != Application.Current.Properties[AppConstants.APP_PASSWORD_PROP].ToString())
                    {
                        DisplayAlert("", "رمز عبور قبلی صحیح نمیباشد", "باش");
                        txtOldPassword.Focus();
                        return;
                    }

                    if (txtPassword.Text != txtConfrimPassword.Text)
                    {

                        DisplayAlert("", "رمز عبور با تکرار آن یکسان نمیباشد", "باش");
                        txtConfrimPassword.Focus();
                        return;
                    }

                    Application.Current.Properties[AppConstants.APP_PASSWORD_PROP] = txtPassword.Text;
                }

                Navigation.PopAsync();
            }
        }

        private bool Validation()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
                return false;
            }
            return true;
        }
    }
}