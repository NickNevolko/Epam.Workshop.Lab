using System.Data.Entity;

namespace PortfolioManagerClient.ProxyCloud.Entities
{
    public class EntityModel : DbContext
    {
        public EntityModel()
            : this("EntityModel")
        { }

        public EntityModel(string conectionString)
            : base(conectionString)
        { }

        public virtual DbSet<DbShare> DbShares { get; set; }
        public virtual DbSet<DbUser> DbUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
                .HasMany(e => e.Shares)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}