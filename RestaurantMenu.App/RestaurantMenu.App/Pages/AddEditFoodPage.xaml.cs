using RestaurantMenu.App.DependencyServices;
using RestaurantMenu.App.Models;
using RestaurantMenu.App.Repositories;
using RestaurantMenu.App.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantMenu.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditFoodPage : ContentPage
    {
        Food _food;
        IList<Category> _categories;
        IFoodRepository _foodContext;
        ICategoryRepository _categoryContext;

        string _imagePath = "";

        public AddEditFoodPage()
        {
            InitializeComponent();
            _food = new Food();
            _foodContext = new FoodRepository();
            _categoryContext = new CategoryRepository();
            InitCategories();



        }
        public AddEditFoodPage(Food food)
        {
            InitializeComponent();

            _foodContext = new FoodRepository();
            _categoryContext = new CategoryRepository();
            InitCategories();

            _food = food;
            txtName.Text = _food.Name;
            lblTitle.Text = $"نام غذا ({_food.Name}):";
            if (_food.ImagePath != "")
            {
                imgFood.Source = ImageSource.FromFile(_food.ImagePath);


            }


            txtDesc.Text = _food.Description;
            txtPrice.Text = _food.Price.ToString();

            int i= _categories.IndexOf(_categories.Where(c=>c.Id==_food.CategoryId).FirstOrDefault());
            pickerCategory.SelectedIndex = i;


        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            imgFood.HeightRequest = imgFood.Width;
        }

        private void InitCategories()
        {
            _categories = _categoryContext.GetAll().ToList();

            pickerCategory.ItemsSource = _categories.ToList();
        }

        private void Ok_Clicked(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (_food.Id == 0)
                {
                    _food.Name = txtName.Text;


                    if (txtDesc.Text == null)
                    {
                        _food.Description = "";
                    }
                    else
                    {
                        _food.Description = txtDesc.Text;

                    }
                    _food.Price = Int32.Parse(txtPrice.Text);
                    _food.CategoryId = ((Category)pickerCategory.SelectedItem).Id;
                    _food.ImagePath = _imagePath;

                    _foodContext.Create(_food);

                }
                else
                {
                    _food.Name = txtName.Text;
                    if (txtDesc.Text == null)
                    {
                        _food.Description = "";
                    }
                    else
                    {
                        _food.Description = txtDesc.Text;

                    }
                    _food.Price = Int32.Parse(txtPrice.Text);
                    _food.CategoryId = ((Category)pickerCategory.SelectedItem).Id;


                    if (_imagePath != "")
                    {

                        _food.ImagePath = _imagePath;
                    }

                    _foodContext.Update(_food);

                }

                Navigation.PopAsync();


            }
        }

        private bool Validation()
        {


            if (txtName.Text == null || txtName.Text == "")
            {
                DisplayAlert("توجه", "تعداد حروف نام باید بین 2 تا 255 حرف باشد", "باش");
                txtName.Focus();
                return false;
            }
            else
            {
                if (txtName.Text.Length < 2 || txtName.Text.Length > 255)
                {

                    DisplayAlert("توجه", "تعداد حروف نام باید بین 2 تا 255 حرف باشد", "باش");
                    txtName.Focus();
                    return false;
                }
            }


            if (txtPrice.Text == null || txtPrice.Text == "")
            {
                DisplayAlert("توجه", "قیمت را صحیح وارد کنید", "باش");
                txtPrice.Focus();
                return false;
            }
            else
            {
                if (txtPrice.Text.Length < 1 || txtPrice.Text.Length > 12)
                {

                    DisplayAlert("توجه", "قیمت را صحیح وارد کنید", "باش");
                    txtPrice.Focus();
                    return false;
                }
            }


            if (pickerCategory.SelectedIndex < 0)
            {
                // DisplayAlert("توجه", "لطفا یک دسته بندی را انتخاب کنید", "باش");
                pickerCategory.Focus();
                return false;
            }


            if (txtDesc.Text != null && txtName.Text.Length > 512)
            {

                DisplayAlert("توجه", "تعداد حروف توضیحات حداکثر 512 حرف می باشد", "باش");
                txtName.Focus();
                return false;

            }
            return true;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync();
        }

        private string _imgName = "IMGFood_" + Guid.NewGuid();
        private async void imgFood_Clicked(object sender, EventArgs e)
        {
            (sender as ImageButton).IsEnabled = false;

            using (var stream = await DependencyService.Get<IPhotoPicker>().GetImageStreamAsync())
            {

                if (stream != null)
                {

                    //imgFood.Source = ImageSource.FromStream(() => stream);

                    _imagePath = DependencyService.Get<IFileManager>().SaveFile(stream, _imgName);
                    imgFood.Source = ImageSource.FromFile(_imagePath);

                }
            }


             (sender as ImageButton).IsEnabled = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.TranslationY = this.Height;
            this.TranslateTo(0, 0, 500, Easing.Linear);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.TranslateTo(0, this.Height, 500, Easing.Linear);


        }

        private void btnDeleteImage_Clicked(object sender, EventArgs e)
        {
            _food.ImagePath = "";
            _imagePath = "";

            imgFood.Source = "defaultFoodImage.jpg";
        }
    }
}