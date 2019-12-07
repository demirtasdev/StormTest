namespace SPTechnicalTest.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SPTechnicalTest.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class StormContext : DbContext
    {
        public StormContext()
            : base("name=StormContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<StormContext>());
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<RFQ> RFQs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //###_FLUENT_API_###
            // Location
            modelBuilder.Entity<Location>()
                .HasKey(l => l.ID);

            // User
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID)
                .HasRequired<Location>(u => u.Location)
                .WithMany(u => u.User)
                .HasForeignKey<double>(u => u.StormLocationID);

            // RFQ
            modelBuilder.Entity<RFQ>()
                .HasKey(r => r.RFQNo);

            // Content
            modelBuilder.Entity<Content>()
                .HasKey(c => c.ID)
                .HasRequired<RFQ>(c => c.RFQ)
                .WithMany(r => r.Content)
                .HasForeignKey<double>(c => c.RFQNo);
        }
    }
}
