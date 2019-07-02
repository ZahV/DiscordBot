using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordBot.Core.Commands
{
    public class PSNtag : ModuleBase<SocketCommandContext>
    {
        [Group("psntag"), Alias("psntags"), Summary("Group to manage PSNtags")]
        public class PSNtagsGroup : ModuleBase<SocketCommandContext>
        {

            [Command("add"), Alias("add"), Summary("Used to set a Tag")]
            public async Task Add(IUser user = null, string name = "")
            {

                if (user == null)
                {
                    await Context.Channel.SendMessageAsync(
                        ":x: You forgot to mention a user! Please use this syntax: !psntag add **<@user>** <psnTag>");
                    return;
                }

                if (user.IsBot)
                {
                    await Context.Channel.SendMessageAsync(
                        ":x: Bots can't use this bot, so you can't give a tag to a bot!");
                    return;
                }

                if (name == "")
                {
                    await Context.Channel.SendMessageAsync($":x: A psn tag that will be set to {user.Username} cannot be empty");
                    return;
                }

                await Context.Channel.SendMessageAsync(
                    $":tada: {Context.User.Username} you have set the the PSN tag for {user.Mention} to {name}");

                await Data.Data.SaveIds(user.Id, name);


            }
        }


    }
}
