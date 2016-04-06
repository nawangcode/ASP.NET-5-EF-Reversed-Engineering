using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ASP5MVC6EF7ReversedWorkaround.Models
{
    public class R5Context : DbContext
    {
        private static bool _created = false;

        public R5Context()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<vwEvent> R5Events { get; set; }
    }
}
