using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PH47185.Models;

namespace PH47185.Data
{
    public class PH47185Context : DbContext
    {
        public PH47185Context (DbContextOptions<PH47185Context> options)
            : base(options)
        {
        }

        public DbSet<PH47185.Models.Category> Category { get; set; } = default!;

        public DbSet<PH47185.Models.Product>? Product { get; set; }

        public DbSet<PH47185.Models.User>? User { get; set; }
        public DbSet<PH47185.Models.Cart>? Cart { get; set; }
    }
}
