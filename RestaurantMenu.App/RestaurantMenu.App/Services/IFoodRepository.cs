using RestaurantMenu.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.App.Services
{
  public  interface IFoodRepository
    {
        IEnumerable<Food> GetAll();

        Food GetById(int id);

        void Create(Food cat);
        
        void Update(Food cat);
        
        void Delete(Food cat);

        void Delete(int id);

    }
}
