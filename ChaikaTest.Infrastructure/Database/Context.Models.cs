using ChaikaTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Infrastructure.Database
{
    public partial class Context
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChaikaTest.Domain.Image>(i =>
            {
                i.HasMany(i => i.Transactions)
                .WithMany(t => t.Images);
            });

            modelBuilder.Entity<Card>(c =>
            {
                c.HasMany(c => c.Transactions)
                .WithOne(t => t.Card)
                .HasForeignKey(t => t.CardId)
                .OnDelete(DeleteBehavior.NoAction);

            });
        }
    }
}
