using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MadEasy.Models;

namespace MadEasy.Data
{
    public class MadEasyContext : DbContext
    {
        public MadEasyContext (DbContextOptions<MadEasyContext> options)
            : base(options)
        {
        }

        public DbSet<MadEasy.Models.Dwelling> Dwelling { get; set; }

        public DbSet<MadEasy.Models.Agent> Agent { get; set; }

        public DbSet<MadEasy.Models.City> City { get; set; }

        public DbSet<MadEasy.Models.Prospect> Prospect { get; set; }

        public DbSet<MadEasy.Models.SalesOffice> SalesOffice { get; set; }
    }
}
