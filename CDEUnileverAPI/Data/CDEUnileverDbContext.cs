
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
        public DbSet<Questionnaire> Questionaires { get; set; }
        public DbSet<QuestionnaireDetail> QuestionaireDetails { get; set;}
        public DbSet<VisitPlan> VisitPlans { get; set; }
        public DbSet<JobTask> JobTasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
