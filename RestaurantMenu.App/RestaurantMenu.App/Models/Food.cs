using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace RestaurantMenu.App.Models
{

    public class Food : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name;


        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;

                OnPropertyChanged();
            }
        }

        private string _desc;


        [MaxLength(512)]
        public string Description
        {
            get { return _desc; }
            set
            {
                if (_desc == value)
                    return;

                _desc = value;
                OnPropertyChanged();

            }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set
            {
                if (_price == value)
                    return;
                _price = value;
                OnPropertyChanged();
            }
        }

        [Indexed]
        public int CategoryId { get; set; }

        private string _imagepath;

        public string ImagePath
        {
            get { return _imagepath; }
            set
            {
                if (_imagepath == value)
                    return;
                _imagepath = value;
                OnPropertyChanged();
            }
        }

        [Ignore]
        public string ImageUri
        {
            get
            {
                if (ImagePath == null || ImagePath == "")
                {
                    return "defaultFoodImage.jpg";


                }
                return _imagepath;
            }
        }

        [Ignore]
        public string PriceToString
        {
            get
            {
                return Price.ToString("N0") + " ریال";
            }
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
