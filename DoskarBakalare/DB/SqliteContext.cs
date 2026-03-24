using DoskarBakalare.Znamky;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoskarBakalare.DB
{
    public class SqliteContext : DbContext
    {
        public DbSet<Zapis> Znamky { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "Products.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
