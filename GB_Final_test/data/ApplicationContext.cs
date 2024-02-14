using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore; //Added for work with SQLite

namespace GB_Final_test.data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AnimalList> AnimalsList { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./data/AnimalsList.db");
        }
    }
}
