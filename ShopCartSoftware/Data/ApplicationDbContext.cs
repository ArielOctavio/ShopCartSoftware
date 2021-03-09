using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ShopCartSoftware.Models;

namespace ShopCartSoftware.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShopCartSoftware.Models.Product> Product { get; set; }
        public DbSet<ShopCartSoftware.Models.Category> Category { get; set; }
    }
}
