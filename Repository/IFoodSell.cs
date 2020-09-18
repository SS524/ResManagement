using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Repository
{
    interface IFoodSell
    {
        public IEnumerable<FoodSell> Get();
        public IQueryable<FoodSell> Get(int id);
        public string Post(FoodSell obj);

    }
}
