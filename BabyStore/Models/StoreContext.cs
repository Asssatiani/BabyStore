using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BabyStore.Models;
using System.Data.Entity;
namespace BabyStore.Models
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}