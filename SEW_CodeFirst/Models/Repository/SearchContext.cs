using Microsoft.EntityFrameworkCore;
using SEW_CodeFirst.Models.DTO;

namespace SEW_CodeFirst.Models.Repository
{
    public class SearchContext : DbContext
    {
        public DbSet<SearchEngine> Engines { get; set; }
        public DbSet<SearchResult> Results { get; set; }
        public DbSet<Log> Logs { get; set; }

        public SearchContext(DbContextOptions<SearchContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
