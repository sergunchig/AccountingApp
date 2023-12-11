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
            var connectionStr = Properties.Settings.Default.DbConnection;
            optionsBuilder.UseNpgsql(connectionStr);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cost>()
            .Property(p => p.Date)
            .HasConversion
    (
            src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
            dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
    );
            base.OnModelCreating(modelBuilder);
        }
    }
}
