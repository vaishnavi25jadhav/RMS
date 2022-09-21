using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResTask.Model;

namespace RestaurantManagement.Data
{
    public class RestaurantManagementContext : DbContext
    {
        public RestaurantManagementContext (DbContextOptions<RestaurantManagementContext> options)
            : base(options)
        {
        }

        public DbSet<ResTask.Model.Category> Category { get; set; }

        public DbSet<ResTask.Model.Menu> Menu { get; set; }

        public DbSet<ResTask.Model.Order> Order { get; set; }
    }
}
