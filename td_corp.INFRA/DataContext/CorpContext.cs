using Flunt.Notifications;
using td_corp.INFRA.Mappings;
using td_corp.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace td_corp.INFRA.DataContext
{
    public class CorpContext : DbContext
    {
        public CorpContext(DbContextOptions options)
        :base(options){
            
        }

        public DbSet<Announce> Announces { get; set; }
        public DbSet<Marking> Markings { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MarkingMap());
            modelBuilder.ApplyConfiguration(new ModelMap());

            modelBuilder.Ignore<Notification>();
        }
    }
}
