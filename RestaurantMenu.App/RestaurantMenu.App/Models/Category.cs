using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RestaurantMenu.App.Models
{
    public class Category : INotifyPropertyChanged
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

        public string IconPath { get; set; }

        [Ignore]
        public Uri IconUri
        {
            get
            {
                return new Uri(IconPath);
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
