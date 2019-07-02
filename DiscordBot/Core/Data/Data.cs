using DiscordBot.Resources;
using DiscordBot.Resources.Database;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Core.Data
{
    public static class Data
    {
        public static string GetIds(ulong UserId)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.PSNtags.Where(x => x.UserId == UserId).Count() < 1)
                {
                    return "";
                }
                return DbContext.PSNtags.Where(x => x.UserId == UserId).Select(x => x.Name).FirstOrDefault();
            }
        }

        public static async Task SaveIds(ulong UserId, string Name)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.PSNtags.Where(x => x.UserId == UserId).Count() < 1)
                {
                    DbContext.PSNtags.Add(new PSNtag
                    {
                        UserId = UserId,
                        Name = Name
                    });
                }
                else
                {
                    PSNtag Current = DbContext.PSNtags.Where(x => x.UserId == UserId).FirstOrDefault(
                    );
                    Current.Name = Name;
                    DbContext.Update(Current);
                }
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
