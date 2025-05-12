using Microsoft.EntityFrameworkCore;
using PFT.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PFT.Persistence.Data
{
    public class PFTDatabaseContext: DbContext
    {
        public PFTDatabaseContext(DbContextOptions<PFTDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Transactions> transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PFTDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transactions>()
                .Property(t => t.TransactionId)
                .ValueGeneratedNever(); // Tell EF you'll manage IDs
            modelBuilder.Entity<Transactions>().Property(t => t.Amount).HasColumnType("decimal(18,2)");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added))
            {

                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
