using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Repository
{
    public class FoodSellRepo:IFoodSell
    {
        private readonly RestaurantContext _context;
        public FoodSellRepo(RestaurantContext context)
        {
            _context = context;
        }
        public IEnumerable<FoodSell> Get()
        {
            return _context.FoodSells.ToList();
        }
        public IQueryable<FoodSell> Get(int id)
        {

            IQueryable<FoodSell> obj = _context.FoodSells.Where(g => g.FoodItemId == id);

            return obj;
        }
        public string Post(FoodSell obj)
        {
            //  _log4net.Info(" Http POST Request done");
            var ob = _context.FoodItems.Where(x=>x.FoodId==obj.FoodItemId).FirstOrDefault();
            if (ob != null && obj.Quantity>0)
            {
                _context.FoodSells.Add(obj);
                _context.SaveChanges();
                return "Success";
            }
            else
            {     
                return "Food is not present in main table";
            }
        }
    }
}
