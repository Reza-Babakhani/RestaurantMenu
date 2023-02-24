using RestaurantMenu.App.Models;
using RestaurantMenu.App.Repositories;
using RestaurantMenu.App.Services;
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
    public partial class EditPage : ContentPage
    {
        ICategoryRepository _categoryContext;
        IList<Category> _categories;
        public EditPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _categoryContext = new CategoryRepository();
            _categories = _categoryContext.GetAll().ToList();
        }

        private void StkCategory_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategotyListPage());
        }

        private void StkFood_Tapped(object sender, EventArgs e)
        {
            if (_categories.Count() <= 0)
            {
                DisplayAlert("هشدار", "ابتدا حداقل یک دسته بندی جدید ایجاد کنید", "باش");
                return;
            }
            Navigation.PushAsync(new FoodListPage());

        }

        private void StkSetting_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());

        }
    }
}