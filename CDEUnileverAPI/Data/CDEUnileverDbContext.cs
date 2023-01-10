
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Data
{
    public class CDEUnileverDbContext : DbContext
    {
        public CDEUnileverDbContext(DbContextOptions<CDEUnileverDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        //public DbSet<Area_Distributor> Areas_Distributors { get; set; }
        //public DbSet<Area_User> Areas_Users { get; set; }
    }
}
