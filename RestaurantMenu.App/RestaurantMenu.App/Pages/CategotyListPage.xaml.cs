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
    public partial class CategotyListPage : ContentPage
    {

        ICategoryRepository _categoryContext;
        ObservableCollection<Category> _categories;

       

        public CategotyListPage()
        {
            InitializeComponent();
            _categoryContext = new CategoryRepository();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetCategories();
            listCategories.ItemsSource = _categories;
        }

        private void GetCategories()
        {
            _categories = null;

            _categories = new ObservableCollection<Category>(_categoryContext.GetAll().ToList());

        }


        private void SearchCategories(string searchText)
        {

            if (searchText != null)
            {
                if (searchText.Trim() == "")
                {
                    listCategories.ItemsSource = _categories;

                }
                else
                {
                    listCategories.ItemsSource = _categories.Where(c => c.Name.Contains(searchBar.Text));

                }

            }
            else
            {
                listCategories.ItemsSource = _categories;

            }
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            var page = new AddEditCategoryPage();
            Navigation.PushModalAsync(page);



        }



        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchCategories(e.NewTextValue);
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void listCategories_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var cat = (Category)e.Item;
                if (cat == null || cat.Id == 0)
                {
                    return;
                }

                var page = new AddEditCategoryPage(cat);

                Navigation.PushModalAsync(page);




            }
            catch
            {

            }
        }

        private async void btnDeleteCategory_Clicked(object sender, EventArgs e)
        {

            Category cat= (Category)((ImageButton)sender).CommandParameter;
            if (Id != null)
            {
                if((new FoodRepository().GetAll().Where(f => f.CategoryId == cat.Id).Count() > 0)){
                   await DisplayAlert("هشدار", $"دسته بندی '{cat.Name}' دارای عضو میباشد و حذف آن ممکن نیست!", "باش");
                        return;
                }
                if (await DisplayAlert("هشدار", $"دسته بندی '{cat.Name}' حذف میشود.ادامه میدهید؟", "بله", "خیر"))
                {
                    _categoryContext.Delete(cat);
                    _categories.Remove(cat);
                }
                
            }

        }
    }
}