using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordBot.Core.Commands
{
    public class PSNtag : ModuleBase<SocketCommandContext>
    {
        [Group("psn"), Alias("psntags"), Summary("Group to manage PSNtags")]
        public class PSNtagsGroup : ModuleBase<SocketCommandContext>
        {

            [Command(""), Alias("me", "my"), Summary("Shows your current PSN tag")]
            public async Task Me(IUser User = null)
            {

                if (User == null)
                {
                    await Context.Channel.SendMessageAsync(
                        $"{Context.User}, your current PSN tag is {Data.Data.GetPsn(Context.User.Id)}");
                }
                else
                {
                    await Context.Channel.SendMessageAsync(
                        $"{User.Username}'s PSN Tag is : {Data.Data.GetPsn(User.Id)}");
                }
            }


            [Command("add"), Alias("add"), Summary("Used to set a PSN Id")]
            public async Task Add(IUser user = null, string name = "")
            {

                if (user == null)
                {
                    await Context.Channel.SendMessageAsync(
                        ":x: You forgot to mention a user! Please use this syntax: !psn add **<@user>** <psn id>");
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
                    await Context.Channel.SendMessageAsync($":x: The PSN Id that will be set to {user.Username} cannot be empty");
                    return;
                }

                await Context.Channel.SendMessageAsync(
                    $":tada: {Context.User.Username} you have set the PSN Id for {user.Mention} to {name}");

                await Data.Data.SavePsn(user.Id, name);


            }
        }
    }

    public class PCtag : ModuleBase<SocketCommandContext>
    {
        [Group("pc"), Alias("pctags"), Summary("Group to manage PC tags")]
        public class PCtagsGroup : ModuleBase<SocketCommandContext>
        {

            [Command(""), Alias("me", "my"), Summary("Shows your current Steam tag")]
            public async Task Me(IUser User = null)
            {

                if (User == null)
                {
                    await Context.Channel.SendMessageAsync(
                        $"{Context.User}, your current PC tag is {Data.Data.GetPC(Context.User.Id)}");
                }
                else
                {
                    await Context.Channel.SendMessageAsync(
                        $"{User.Username}'s Steam Id is : {Data.Data.GetPC(User.Id)}");
                }
            }


            [Command("add"), Alias("add"), Summary("Used to set a Steam Id")]
            public async Task Add(IUser user = null, string name = "")
            {

                if (user == null)
                {
                    await Context.Channel.SendMessageAsync(
                        ":x: You forgot to mention a user! Please use this syntax: !pc add **<@user>** <steam id>");
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
                    await Context.Channel.SendMessageAsync(
                        $":x: The Steam Id that will be set to {user.Username} cannot be empty");
                    return;
                }

                await Context.Channel.SendMessageAsync(
                    $":tada: {Context.User.Username} you have set the Steam ID for {user.Mention} to {name}");

                await Data.Data.SavePC(user.Id, name);
            }
        }
    }

    public class XBOXtag : ModuleBase<SocketCommandContext>
    {
        [Group("xbox"), Alias("xboxtags"), Summary("Group to manage XBOX tags")]
        public class XBOXtagsGroup : ModuleBase<SocketCommandContext>
        {

            [Command(""), Alias("me", "my"), Summary("Shows your current Xbox tag")]
            public async Task Me(IUser User = null)
            {

                if (User == null)
                {
                    await Context.Channel.SendMessageAsync(
                        $"{Context.User}, your current XBOX tag is {Data.Data.GetXbox(Context.User.Id)}");
                }
                else
                {
                    await Context.Channel.SendMessageAsync(
                        $"{User.Username}'s Xbox Id is : {Data.Data.GetXbox(User.Id)}");
                }
            }


            [Command("add"), Alias("add"), Summary("Used to set a XBOX Tag")]
            public async Task Add(IUser user = null, string name = "")
            {

                if (user == null)
                {
                    await Context.Channel.SendMessageAsync(
                        ":x: You forgot to mention a user! Please use this syntax: !xbox add **<@user>** <xbox id>");
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
                    await Context.Channel.SendMessageAsync(
                        $":x: The Xbox tag that will be set to {user.Username} cannot be empty");
                    return;
                }

                await Context.Channel.SendMessageAsync(
                    $":tada: {Context.User.Username} you have set the Xbox ID for {user.Mention} to {name}");

                await Data.Data.SaveXbox(user.Id, name);
            }
        }
    }
    public class AllInfo : ModuleBase<SocketCommandContext>
    {

        [Command("info"), Alias("info"), Summary("Used to see all ID's for a user")]
        public async Task Info(IUser User = null)
        {

            if (User == null)
            {
                await Context.Channel.SendMessageAsync(
                    $"{Context.User}, your current Id's are: PC - {Data.Data.GetPC(Context.User.Id)}\nPSN - {Data.Data.GetPsn(Context.User.Id)}\nXbox - {Data.Data.GetXbox(Context.User.Id)}");
            }
            else
            {
                await Context.Channel.SendMessageAsync(
                    $"{User.Username}'s current IDs are : PC - {Data.Data.GetPC(User.Id)}\nPSN - {Data.Data.GetPsn(User.Id)}\nXbox - {Data.Data.GetXbox(User.Id)}");
            }
        }
    }

    public class GetHelp : ModuleBase<SocketCommandContext>
    {
        [Command("help"), Alias("id"), Summary("Useful information about commands")]
        public async Task Help()
        {
            await Context.Channel.SendMessageAsync("To add your gamer tag in the discord channel use the following syntax :!<Name of platform> add <@discordUser> <your ID in the selected platform> \nFor example: !psn add @dscBigot dscBigot \nThe available platforms at the moment are pc,psn,xbox \nUse !info to share all of your IDs in the channel or use !info <@discordUser> to see the IDs of a selected user \nUse !<platform name> To see your current ID for the selected platform or use !<platform name> <@DiscordUser> to see another person's spefic Id \nFor example: !psn @dscBigot");
        }
    }
}
