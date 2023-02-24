using RestaurantMenu.App.Constants;
using RestaurantMenu.App.Models;
using RestaurantMenu.App.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.App.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        SQLiteConnection _context;
        public FoodRepository()
        {
            _context = new SQLiteConnection(DbConstants.DatabasePath);
            _context.CreateTable(typeof(Food));
           // _context.CreateTable<Food>();
        }

        public  void Create(Food f)
        {
             _context.Insert(f);
            CloseConnection();

        }

        public void Update(Food f)
        {
             _context.Update(f);
            CloseConnection();
        }

        public void Delete(Food f)
        {
            _context.Delete(f);
            CloseConnection();

        }

        public void Delete(int id)
        {
             _context.Delete( GetById(id));
            CloseConnection();

        }

        public IEnumerable<Food> GetAll()
        {
            var result =  _context.Table<Food>().ToList();
            CloseConnection();
            return result;

        }

        public Food GetById(int id)
        {
            var f =  _context.Table<Food>().FirstOrDefault(c => c.Id == id);
            CloseConnection();
            return f;

        }



        private void CloseConnection()
        {
          //  _context.Close();
        }
    }
}
