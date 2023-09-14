using AdvancedProgramming_Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedProgramming_Lesson1.Data
{
    public class MvcDrzewaContext : DbContext
    {
        public MvcDrzewaContext(DbContextOptions<MvcDrzewaContext> options)
        : base(options)
        {
        }
        public DbSet<Drzewa> Drzewa { get; set; }
    }
}