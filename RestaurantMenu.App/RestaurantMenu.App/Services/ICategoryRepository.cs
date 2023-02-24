using RestaurantMenu.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.App.Services
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category GetById(int id);

        void Create(Category cat);
        
        void Update(Category cat);

        void Delete(Category cat);

        void Delete(int id);

    }
}
