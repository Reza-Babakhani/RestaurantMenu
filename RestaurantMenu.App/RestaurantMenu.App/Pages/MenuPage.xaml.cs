using RestaurantMenu.App.Constants;
using RestaurantMenu.App.Models;
using RestaurantMenu.App.Repositories;
using RestaurantMenu.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace RestaurantMenu.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        ICategoryRepository _categoryContext;
        IFoodRepository _foodContext;
        IList<Category> _categories;
        IList<Food> _foods;
        int _selectedCategory = 0;
        bool IsSearching = false;


        public  MenuPage()
        {
            InitializeComponent();

            _categories = new List<Category>();
            _foods = new List<Food>();
            _categoryContext = new CategoryRepository();
            _foodContext = new FoodRepository();

         
        }

        
        protected  override void OnAppearing()
        {
            base.OnAppearing();

            _categories = _categoryContext.GetAll().ToList();
            _foods = _foodContext.GetAll().ToList();


           

            InitCategories();
            InitFoods();

            if (Application.Current.Properties.ContainsKey(AppConstants.RESTAURANT_NAME_PROP))
            {
                txtTitle.Text = "منو " + Application.Current.Properties[AppConstants.RESTAURANT_NAME_PROP].ToString();
            }


        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            scrollCategory.ScrollToAsync(stkCategories.Width, 0, false);

            
        }


        private void InitCategories()
        {
            try
            {
                stkCategories.Children.Clear();

                Button btnAllCat = new Button();
                btnAllCat.Text = "همه";
                btnAllCat.Clicked += Categoty_Clicked;
                btnAllCat.SetDynamicResource(VisualElement.StyleProperty, "SelectedCat");
                btnAllCat.CommandParameter = 0;
                stkCategories.Children.Add(btnAllCat);

                foreach (var item in _categories)
                {
                    Button b = new Button();
                    b.Text = item.Name;
                    b.Clicked += Categoty_Clicked;
                    b.SetDynamicResource(VisualElement.StyleProperty, "DeSelectedCat");
                    b.CommandParameter = item.Id;
                    stkCategories.Children.Add(b);

                }

            }
            catch
            {

            }

        }


        private void Categoty_Clicked(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                CategoriesUIChange(b);

                _selectedCategory = (int)b.CommandParameter;

                InitFoods();
            }
            catch
            {

            }

        }


        private void CategoriesUIChange(Button btn)
        {
            try
            {
                foreach (var item in stkCategories.Children)
                {
                    Button l = item as Button;

                    if (l == btn)
                    {
                        btn.SetDynamicResource(VisualElement.StyleProperty, "SelectedCat");
                    }
                    else
                    {
                        item.SetDynamicResource(VisualElement.StyleProperty, "DeSelectedCat");

                    }
                }
            }
            catch
            {
               
            }
        }


        private void InitFoods()
        {
            var result= _foods;
            if (_selectedCategory != 0)
            {
              result= result.Where(f => f.CategoryId == _selectedCategory).ToList();
            }
            if (searchBar.Text != null)
            {
               result= result.Where(f => f.Name.Contains(searchBar.Text) || f.Description.Contains(searchBar.Text)).ToList();
            }
            listFoods.ItemsSource = result;
        }

        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            searchBar.Text = "";
            if (IsSearching)
            {
                IsSearching = false;
                stkSearch.IsVisible = false;
                btnSearch.RotateTo(0);

                btnSearch.Source = "IconSearch.png";
            }
            else
            {
                IsSearching = true;
                stkSearch.IsVisible = true;
                btnSearch.RotateTo(360);

                btnSearch.Source = "IconClose.png";

            }

          
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            InitFoods();

        }

       

        private void listFoods_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var foods = (List<Food>)listFoods.ItemsSource;

            FoodCaroselPage fcp = new FoodCaroselPage(foods,e.ItemIndex);

            Navigation.PushAsync(fcp);
            
        }
    }
}