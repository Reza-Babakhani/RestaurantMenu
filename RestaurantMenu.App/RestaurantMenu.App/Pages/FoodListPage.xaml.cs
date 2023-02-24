using RestaurantMenu.App.Models;
using RestaurantMenu.App.Repositories;
using RestaurantMenu.App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMenu.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodListPage : ContentPage
    {

        IFoodRepository _foodContext;
        ObservableCollection<Food> _foods;

        

        public FoodListPage()
        {
            InitializeComponent();
            _foodContext = new FoodRepository();
           

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

           

            GetFoods();
            listFoods.ItemsSource = _foods;
        }

        private void GetFoods()
        {
            _foods = null;
            
            _foods = new ObservableCollection<Food>(_foodContext.GetAll().ToList());

        }


        private void SearchFoods(string searchText)
        {

            if (searchText != null)
            {
                if (searchText.Trim() == "")
                {
                    listFoods.ItemsSource = _foods;

                }
                else
                {
                    listFoods.ItemsSource = _foods.Where(c => c.Name.Contains(searchText)||c.Description.Contains(searchText));

                }

            }
            else
            {
                listFoods.ItemsSource = _foods;

            }
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            var page = new AddEditFoodPage();
            Navigation.PushAsync(page);



        }



        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchFoods(e.NewTextValue);
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void listFoods_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var f = (Food)e.Item;
                if (f == null || f.Id == 0)
                {
                    return;
                }

                var page = new AddEditFoodPage(f);

                Navigation.PushAsync(page);




            }
            catch
            {

            }
        }

        private async void btnDeleteFood_Clicked(object sender, EventArgs e)
        {

            Food f= (Food)((ImageButton)sender).CommandParameter;
            if (Id != null)
            {
                
                if (await DisplayAlert("هشدار", $"عنوان '{f.Name}' حذف میشود.ادامه میدهید؟", "بله", "خیر"))
                {
                    _foodContext.Delete(f);
                    _foods.Remove(f);
                }
                
            }

        }
    }
}