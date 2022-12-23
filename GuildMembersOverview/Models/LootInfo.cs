using System.ComponentModel.DataAnnotations;

namespace GuildMembersOverview.Models
{
    public class LootInfo
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Received { get; set; }
        public string Item { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}
