using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class RestaurantContext:DbContext
    {
        public RestaurantContext()
        {

        }
        public RestaurantContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<FoodItem> FoodItems { get; set; }
        public virtual DbSet<FoodSell> FoodSells { get; set; }
    }
}
