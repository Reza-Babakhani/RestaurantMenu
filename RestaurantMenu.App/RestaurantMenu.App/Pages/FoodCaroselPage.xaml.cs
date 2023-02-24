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
    public partial class FoodCaroselPage : CarouselPage
    {
        IList<Food> _foods;
        int _index;
      



        public FoodCaroselPage(List<Food> foods, int index)
        {
            InitializeComponent();
            _foods = foods;
            _index = index;


            InitPages();
        }

        private void InitPages()
        {
            foreach(var food in _foods)
            {
                Children.Add(new FoodCaroselItemPage(food));
            }

           SelectedItem = Children[_index];
        }



        ////IList<Food> _foods;
        ////int _index;
        ////int _initPageIndex;

        ////FoodCaroselItemPage _pageL;
        ////FoodCaroselItemPage _pageM;
        ////FoodCaroselItemPage _pageR;


        ////public FoodCaroselPage(List<Food> foods, int index)
        ////{
        ////    InitializeComponent();
        ////    _foods = foods;
        ////    _index = index;


        ////    InitPages();

        ////    _initPageIndex = Children.IndexOf(CurrentPage);
        ////}


        ////private void InitPages()
        ////{
        ////    int selectedPage=0;
        ////    _pageL = null;
        ////    _pageM = null;
        ////    _pageR = null;

        ////    Children.Clear();


        ////    if (_index < 0)
        ////    {
        ////        Navigation.PopModalAsync();
        ////    }
        ////    if (_foods.Count == 1)
        ////    {

        ////        _pageM = new FoodCaroselItemPage(_foods[_index]);

        ////    }
        ////    else if (_foods.Count == 2)
        ////    {
        ////        if (_index == 0)
        ////        {
        ////            _pageM = new FoodCaroselItemPage(_foods[_index]);
        ////            _pageR = new FoodCaroselItemPage(_foods[_index + 1]);

        ////            selectedPage = 0;

        ////        }
        ////        else if (_index == _foods.Count - 1)
        ////        {
        ////            _pageL = new FoodCaroselItemPage(_foods[_index - 1]);

        ////            _pageM = new FoodCaroselItemPage(_foods[_index]);

        ////            selectedPage = 1;

        ////        }


        ////    }
        ////    else if (_foods.Count > 2)
        ////    {
        ////        if (_index == 0)
        ////        {
        ////            _pageM = new FoodCaroselItemPage(_foods[_index]);
        ////            _pageR = new FoodCaroselItemPage(_foods[_index + 1]);
        ////            selectedPage = 0;

        ////        }
        ////        else if (_index == _foods.Count - 1)
        ////        {
        ////            _pageL = new FoodCaroselItemPage(_foods[_index - 1]);

        ////            _pageM = new FoodCaroselItemPage(_foods[_index]);

        ////            selectedPage = 1;
        ////        }
        ////        else
        ////        {
        ////            _pageL = new FoodCaroselItemPage(_foods[_index - 1]);

        ////            _pageM = new FoodCaroselItemPage(_foods[_index]);

        ////            _pageR = new FoodCaroselItemPage(_foods[_index + 1]);

        ////            selectedPage = 1;


        ////        }


        ////    }

        ////    if (_pageL != null)
        ////    {
        ////        Children.Add(_pageL);

        ////    }
        ////    if (_pageM != null)
        ////    {
        ////        Children.Add(_pageM);

        ////    }
        ////    if (_pageR != null)
        ////    {
        ////        Children.Add(_pageR);

        ////    }

        ////    SelectedItem = selectedPage;
        ////}

        ////protected override void OnCurrentPageChanged()
        ////{
        ////    base.OnCurrentPageChanged();

        ////    int currentIndex= Children.IndexOf(CurrentPage);

        ////    if (_initPageIndex < currentIndex)
        ////    {
        ////        _index = _index + 1;

        ////    }
        ////    else if(_initPageIndex > currentIndex)
        ////    {
        ////        _index = _index - 1;

        ////    }
        ////    InitPages();
        ////}



    }
}