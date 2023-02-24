using RestaurantMenu.App.Models;
using RestaurantMenu.App.Repositories;
using RestaurantMenu.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMenu.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditCategoryPage : ContentPage
    {
        Category _cat;
       
        ICategoryRepository _categoryContext;

        public AddEditCategoryPage()
        {
            InitializeComponent();
            _cat = new Category();
            _categoryContext = new CategoryRepository();

        }
        public AddEditCategoryPage(Category cat)
        {
            InitializeComponent();

            _cat = cat;
            txtName.Text = _cat.Name;
            lblTitle.Text = $"نام دسته بندی ({_cat.Name}):";
            _categoryContext = new CategoryRepository();

        }
      

        private void Ok_Clicked(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 2 || txtName.Text.Length > 255)
            {

                DisplayAlert("توجه", "تعداد حروف باید بین 2 تا 255 حرف باشد", "باش");
                txtName.Focus();
                return;
            }
            if (_cat.Id == 0)
            {
                _cat.Name = txtName.Text;
                _cat.IconPath = "";
                _categoryContext.Create(_cat);
                
                Navigation.PopModalAsync();

            }
            else
            {
                _cat.Name = txtName.Text;

                _categoryContext.Update(_cat);
               
                Navigation.PopModalAsync();
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}