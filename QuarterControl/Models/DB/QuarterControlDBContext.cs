using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Models.DB
{
    public class QuarterControlDBContext : DbContext 
    {
        public QuarterControlDBContext(DbContextOptions<QuarterControlDBContext> options)
           : base(options)
        {

        }

        public DbSet<AngusInspect> AngusInspects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AngusInspect>().ToTable("AngusInspect");
        }
    }
}
