using Microsoft.EntityFrameworkCore;
using ShopBridgeInventoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeInventoryApi.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<InventoryMaster> InventoryMasters { get; set; }

        
    }
}
