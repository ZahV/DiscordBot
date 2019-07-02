using System.ComponentModel.DataAnnotations;

namespace DiscordBot.Resources
{
    public class PCtag
    {
        [Key]
        public ulong UserId { get; set; }

        public string Name { get; set; }
    }
}
