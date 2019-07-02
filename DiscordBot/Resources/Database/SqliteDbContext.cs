using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Resources.Database
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<PSNtag> PSNtags { get; set; }
        public DbSet<PCtag> PCtags { get; set; }
        public DbSet<XBOXtag> XBOXtags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            Options.UseSqlite($"Data Source=Data\\Database.sqlite");
        }

    }
}
