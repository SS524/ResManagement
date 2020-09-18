using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Repository;

namespace RestaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {

        readonly log4net.ILog _log4net;



        /*  private readonly RestaurantContext _context;
             public FoodItemController(RestaurantContext context)
             {
                 _context = context;

                 _log4net = log4net.LogManager.GetLogger(typeof(FoodItemController));
             }*/

        private readonly FoodItemRepo _context;


        public FoodItemController(FoodItemRepo obj)
        {
            _context = obj;
            _log4net = log4net.LogManager.GetLogger(typeof(FoodItemController));
        }


        // GET: api/FoodItem
        [HttpGet]
        public IActionResult Get()
        {
            //  return Ok(_context.FoodItems.ToList());
            return Ok(_context.Get());


        }

        // GET: api/FoodItem/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            /* IQueryable< FoodItem> obj=  _context.FoodItems.Where(x=>x.FoodId==id);
            FoodItem ob = obj.FirstOrDefault();
             if (obj.Count()==0)
              {
                  return BadRequest(ob);
              }

                  return Ok(ob); */

            IQueryable<FoodItem> obj = _context.Get(id);
            if (obj.Count() > 0)
                return Ok(obj.FirstOrDefault());
            return BadRequest(obj);




        }

        // POST: api/FoodItem
        [HttpPost]
        public IActionResult Post([FromBody] FoodItem value)
        {
              _log4net.Info(" Http POST Request");

            /* _context.FoodItems.Add(value);
             _context.SaveChanges();
             return "Success";
             */
            string s = "Success";
            if (_context.Post(value) == s)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }




        }

        // PUT: api/FoodItem/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] FoodItem value)
        {

            /* IQueryable<FoodItem > obj = _context.FoodItems.Where(x=>x.FoodId==id);
                    if (obj.Count()>0)
                    {
                     FoodItem ob = obj.FirstOrDefault();
                     ob.FoodName = value.FoodName;
                     ob.FoodType = value.FoodType;
                     ob.FoodPrice = value.FoodPrice;
                     ob.IsAvailable = value.IsAvailable;
                     ob.HomeDelivery = value.HomeDelivery;

                     _context.SaveChanges();
                     return "Successfully Updated";

                 }


                    return "Id does not exist";
                    */
            return _context.Put(id, value);




        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            /*IQueryable< FoodItem> obj = _context.FoodItems.Where(x=>x.FoodId==id);
           
            if (obj.Count() > 0)
            {
                FoodItem ob = obj.FirstOrDefault();
                _context.FoodItems.Remove(ob);
                _context.SaveChanges();
                return "Successfully Deleted";
            }
            return "Id Does not exist";
            */
            return (_context.Delete(id));



        }
    }
}
