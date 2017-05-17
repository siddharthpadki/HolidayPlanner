using HolidayResort1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HolidayResort1.Context
{
    public class HolidayDBContext : DbContext
    {
        public DbSet<HolidayPlanner> SummerHolidayResortPlanner { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure holiday as PK for the table
            modelBuilder.Entity<HolidayPlanner>()
                .HasKey(e => e.HolidayPlannerID);



        }

    }
}