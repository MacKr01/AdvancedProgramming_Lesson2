using AdvancedProgramming_Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedProgramming_Lesson1.Data
{
    public class MvcNarzedziaContext : DbContext
    {
        public MvcNarzedziaContext(DbContextOptions<MvcNarzedziaContext> options)
        : base(options)
        {
        }
        public DbSet<Narzedzia> Narzedzia { get; set; }
    }
}
