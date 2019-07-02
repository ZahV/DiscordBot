using DiscordBot.Resources;
using DiscordBot.Resources.Database;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Core.Data
{
    public static class Data
    {
        public static string GetPsn(ulong UserId)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.PSNtags.Where(x => x.UserId == UserId).Count() < 1)
                {
                    return "User does not have a PSN yet";
                }
                return DbContext.PSNtags.Where(x => x.UserId == UserId).Select(x => x.Name).FirstOrDefault();
            }
        }

        public static async Task SavePsn(ulong UserId, string Name)
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
        public static string GetPC(ulong UserId)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.PCtags.Where(x => x.UserId == UserId).Count() < 1)
                {
                    return "User does not have a Steam ID yet";
                }
                return DbContext.PCtags.Where(x => x.UserId == UserId).Select(x => x.Name).FirstOrDefault();
            }
        }

        public static async Task SavePC(ulong UserId, string Name)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.PCtags.Where(x => x.UserId == UserId).Count() < 1)
                {
                    DbContext.PCtags.Add(new PCtag
                    {
                        UserId = UserId,
                        Name = Name
                    });
                }
                else
                {
                    PCtag Current = DbContext.PCtags.Where(x => x.UserId == UserId).FirstOrDefault(
                    );
                    Current.Name = Name;
                    DbContext.Update(Current);
                }
                await DbContext.SaveChangesAsync();
            }
        }
        public static string GetXbox(ulong UserId)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.XBOXtags.Where(x => x.UserId == UserId).Count() < 1)
                {
                    return "User does not have a Xbox ID yet";
                }
                return DbContext.XBOXtags.Where(x => x.UserId == UserId).Select(x => x.Name).FirstOrDefault();
            }
        }

        public static async Task SaveXbox(ulong UserId, string Name)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.XBOXtags.Where(x => x.UserId == UserId).Count() < 1)
                {
                    DbContext.XBOXtags.Add(new XBOXtag
                    {
                        UserId = UserId,
                        Name = Name
                    });
                }
                else
                {
                    XBOXtag Current = DbContext.XBOXtags.Where(x => x.UserId == UserId).FirstOrDefault(
                    );
                    Current.Name = Name;
                    DbContext.Update(Current);
                }
                await DbContext.SaveChangesAsync();
            }
        }
    }
}

