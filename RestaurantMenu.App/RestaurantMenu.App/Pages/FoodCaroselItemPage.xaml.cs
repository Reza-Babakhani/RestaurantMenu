using RestaurantMenu.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMenu.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodCaroselItemPage : ContentPage
    {
        Food _food;
        public FoodCaroselItemPage(Food food)
        {
            InitializeComponent();
            _food = food;
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lblName.Text ="   "+ _food.Name;
            lblPrice.Text ="   "+ _food.PriceToString;
            lblDesc.Text ="   "+ _food.Description;
            imgFood.Source = _food.ImageUri;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            imgFood.HeightRequest = imgFood.Width;
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}