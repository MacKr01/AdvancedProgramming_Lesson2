using AdvancedProgramming_Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedProgramming_Lesson1.Data
{
    public class MvcWarzywaContext : DbContext
    {
        public MvcWarzywaContext(DbContextOptions<MvcWarzywaContext> options)
        : base(options)
        {
        }
        public DbSet<Warzywa> Warzywa { get; set; }
    }
}