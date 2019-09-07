using Microsoft.EntityFrameworkCore;

namespace AnemicDomain
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}