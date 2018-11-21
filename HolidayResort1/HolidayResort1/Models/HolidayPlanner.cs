using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net.Http;

namespace HolidayResort1.Models
{
    public class HolidayPlanner
    {
        //public HolidayPlanner() { }

        public int HolidayPlannerID { get; set; }
        public string Images { get; set; }       
        public string Country { get; set; }
        public string Resort { get; set; }
        public string Profile { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }

    public class HolidayDBContext : DbContext
    {
        public DbSet<HolidayPlanner> HolidayPlanners { get; set; }
    }
}