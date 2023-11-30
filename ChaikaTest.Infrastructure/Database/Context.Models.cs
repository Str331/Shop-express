using ChaikaTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Infrastructure.Database
{
    public partial class Context
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>(t =>
            {
                t.HasKey(t => t.Id);
            });
        }
    }
}
