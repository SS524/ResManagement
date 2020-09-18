using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Repository
{
    public interface IFoodItem
    {
     public   IEnumerable<FoodItem> Get();
        public IQueryable< FoodItem> Get(int Id);
       public string Post(FoodItem data);
        public string Delete(int Id);
        public string Put(int id, FoodItem obj);

    }
}
