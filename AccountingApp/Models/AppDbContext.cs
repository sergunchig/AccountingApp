using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Models
{
    public class AppDbContext :DbContext
    {
        public DbSet<Cathegory> Cathegories { get; set;}
        public DbSet<Cost> Costs { get; set;}

        public AppDbContext(): base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStr = "Host=localhost;Port=5432;Database=MyAccountingDb;Username=postgres;Password=admin";
            optionsBuilder.UseNpgsql(connectionStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
