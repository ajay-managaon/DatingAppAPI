using datingapp_service.datingapp.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.data
{
    public class DatingAppDBContext : DbContext
    {
        public DatingAppDBContext()
        {

        }
        public DatingAppDBContext(DbContextOptions<DatingAppDBContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DatingAppConnectionString"].ConnectionString);
            }
        }

        public DbSet<Values> tbl_value { get; set; }
        public DbSet<User> tbl_User { get; set; }
  }
}
