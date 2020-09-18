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
    public class FoodSellController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        /* private readonly RestaurantContext _context;
         public FoodSellController(RestaurantContext context)
         {
             _context = context;
             _log4net = log4net.LogManager.GetLogger(typeof(FoodSellController));
         }*/
        private readonly FoodSellRepo _context;
        public FoodSellController(FoodSellRepo obj)
        {
            _context = obj;
            _log4net = log4net.LogManager.GetLogger(typeof(FoodSellController));
        }
        // GET: api/FoodSell
        [HttpGet]
        public IActionResult Get()
        {
            //  return _context.FoodSells.ToList();
            return Ok(_context.Get());
        }

        // GET: api/FoodSell/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            /* IEnumerable<FoodSell> sells = _context.FoodSells.ToList();
            sells = from s in sells where s.FoodItemId == id select s;
            return sells; */

            IQueryable<FoodSell> obj = _context.Get(id);
            if (obj.Count() > 0)
                return Ok(obj);
          
            return BadRequest(obj);
        }

        // POST: api/FoodSell
        [HttpPost]
        public IActionResult Post([FromBody] FoodSell value)
        {

            /* _context.FoodSells.Add(value);
             _context.SaveChanges();
             return "Successfully Sell Details Added"; */
            //  return _context.Post(value);
            string s = "Success";
            if (_context.Post (value)== s)
            {
                return Ok();
            }
            else
            {
                
                return BadRequest();
            }

        }

        // PUT: api/FoodSell/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
