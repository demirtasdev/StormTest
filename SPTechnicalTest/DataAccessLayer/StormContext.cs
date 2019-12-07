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
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<RFQ> RFQs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //###_FLUENT_API_###
            // User
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID)
                .HasKey(u => u.LoginID);
            modelBuilder.Entity<User>()
                .HasRequired<Location>(u => u.Location)
                .WithMany(l => l.User)
                .HasForeignKey<double>(u => u.StormLocationID);

            // RFQ
            modelBuilder.Entity<RFQ>()
                .HasKey(r => r.RFQNo);
            modelBuilder.Entity<RFQ>()
                .HasRequired<User>(r => r.User)
                .WithMany(u => u.RFQs)
                .HasForeignKey<string>(r => r.LoginID);

            // Content
            modelBuilder.Entity<Content>()
                .HasKey(c => c.ID);
            modelBuilder.Entity<Content>()
                .HasRequired<RFQ>(c => c.RFQ)
                .WithMany(r => r.Content)
                .HasForeignKey<double>(c => c.RFQNo);

            // Location
            modelBuilder.Entity<Location>()
                .HasKey(l => l.ID);
        }
    }
}
