using Microsoft.EntityFrameworkCore;
using Mission007.Models;

namespace Mission06.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
        {
        }

        public DbSet<SubmitMovie> Movies { get; set;}

        public DbSet<Categories> Categories { get; set;}

        
    
    }
}
