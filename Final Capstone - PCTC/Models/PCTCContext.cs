using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Final_Capstone___PCTC.Models
{
    public class PCTCContext : DbContext
    {
        public DbSet<PCTCUser> PCTCUsers { get; set; }
        public DbSet<TimeCapsule> TCs { get; set; }
    }
}