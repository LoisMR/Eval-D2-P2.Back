using Eval_D2_P2.Entity;
using Microsoft.EntityFrameworkCore;

namespace Eval_D2_P2.DAL
{
    public class EvalDbContext : DbContext
    {
        public EvalDbContext(DbContextOptions<EvalDbContext> options)
        : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
