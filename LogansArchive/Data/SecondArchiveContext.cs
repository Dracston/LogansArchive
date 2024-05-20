using LogansArchive.Models;
using Microsoft.EntityFrameworkCore;


namespace LogansArchive.Data
{
    public class SecondArchiveContext : DbContext
    {
        public SecondArchiveContext(DbContextOptions<SecondArchiveContext> options) : base(options)
        {
        }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Connection> Connections { get; set; }
    }
}
