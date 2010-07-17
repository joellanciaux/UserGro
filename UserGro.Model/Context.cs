using System.Data.Entity;

namespace UserGro.Model
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        //methods
        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserName);
            modelBuilder.Entity<Group>().HasKey(g => g.Id);            
        }
    }

}