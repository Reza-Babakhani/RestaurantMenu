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
    public class CategoryRepository : ICategoryRepository
    {

        SQLiteConnection _context;
        public CategoryRepository()
        {
            _context = new SQLiteConnection(DbConstants.DatabasePath);
            _context.CreateTable(typeof(Category));
          //  _context.CreateTable<Category>();
        }

        public void Create(Category cat)
        {
             _context.Insert(cat);
            CloseConnection();

        }

        public void Update(Category cat)
        {
             _context.Update(cat);
            CloseConnection();
        }

        public void Delete(Category cat)
        {
             _context.Delete(cat);
            CloseConnection();

        }

        public void Delete(int id)
        {
             _context.Delete(GetById(id));
            CloseConnection();

        }

        public IEnumerable<Category> GetAll()
        {
           
            var result =  _context.Table<Category>().ToList();
            CloseConnection();
            return result;

        }

        public Category GetById(int id)
        {
            var cat = _context.Table<Category>().FirstOrDefault(c => c.Id == id);
            CloseConnection();
            return cat;

        }



        private void CloseConnection()
        {
           // _context.Close();
        }
    }
}
