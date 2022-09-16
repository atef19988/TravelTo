using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelTo.Domain.Models;

namespace TravelTo.Ef.Data
{
    public class TrvelToDbContext : DbContext
    {

        public TrvelToDbContext(DbContextOptions<TrvelToDbContext> options) : base(options)
        {

        }

        
            public virtual DbSet<TbSlider> TbSliders { get; set; } 
            public virtual DbSet<TbLocationTour> TbLocationTours  { get; set; }
            public virtual DbSet<TbSettings> TbSettingss { get; set; }
 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            modelBuilder.Entity<TbCheckoutTourUser>()
                .HasOne(a=>a.TbTour).WithMany(c=>c.TbCheckoutTourUsers)
                .HasForeignKey(a=>a.TourId);
            
            modelBuilder.Entity<TbCompetitionUser>()
               .HasOne(a => a.TbCompetition).WithMany(c => c.TbCompetitionUsers)
               .HasForeignKey(a => a.CompetitionId);


            base.OnModelCreating(modelBuilder);
        }

    }
}
