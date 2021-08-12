//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PickandDrop.Models
//{
//    public class CustomerContext : DbContext
//    {
//        private readonly DbContextOptions _options;

//        public CustomerContext(DbContextOptions options) : base()
//        {
//            _options = options;
//        }
         
//        public DbSet<Customer> customers { get; set; }

//        public DbSet<Status> statuses { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}
