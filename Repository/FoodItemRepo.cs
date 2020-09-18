using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Repository
{
    public class FoodItemRepo : IFoodItem
    {
        private readonly RestaurantContext _context;
        public FoodItemRepo(RestaurantContext context)
        {
            _context = context;
        }

        public IEnumerable<FoodItem> Get()
        {
            return _context.FoodItems.ToList();
        }

        public IQueryable<FoodItem> Get(int id)
        {

            IQueryable<FoodItem> obj = _context.FoodItems.Where(g => g.FoodId == id);

            return obj;
        }


        public string Post(FoodItem obj)
        {
            //  _log4net.Info(" Http POST Request done");
            if (obj.FoodPrice > 0)
            {
                _context.FoodItems.Add(obj);
                _context.SaveChanges();
                return "Success";
            }
            else
            {
                return "Price is negative";
            }
            
        }


        public string Put(int id, FoodItem value)
        {

            IQueryable<FoodItem> obj = _context.FoodItems.Where(g => g.FoodId == id);
            if (obj.Count() > 0)

            {
                FoodItem obj1 = obj.FirstOrDefault();
                obj1.FoodName = value.FoodName;
                obj1.FoodType = value.FoodType;
                obj1.FoodPrice = value.FoodPrice;
                obj1.IsAvailable = value.IsAvailable;
                obj1.HomeDelivery = value.HomeDelivery;

                _context.SaveChanges();
                return "Successfully Updated";
            }
            else
            {
                return "Id does not exist";
            }
        }

        public string Delete(int id)
        {
            IQueryable<FoodItem> obj = _context.FoodItems.Where(g => g.FoodId== id);
            if (obj.Count() > 0)
            {
                IQueryable<FoodSell> obj2 = _context.FoodSells.Where(x => x.FoodItemId == id);
                foreach(var item in obj2)
                {
                    _context.FoodSells.Remove(item);
                }
                _context.FoodItems.Remove(obj.FirstOrDefault());
                _context.SaveChanges();
                return "Successfully Deleted";
            }

            return "Id does not exist";

        }
    }
}
