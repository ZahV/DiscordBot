using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace DiscordBot.Resources.Database
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<PSNtag> PSNtags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            string DbLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace(@"bin\Debug\netcoreapp2.1", @"Data\");
            Options.UseSqlite($"Data Source={DbLocation}Database.sqlite");
        }

    }
}
