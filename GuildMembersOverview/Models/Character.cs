using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GuildMembersOverview.Models
{
    public class ClassAndRole
    {
        public enum Class
        {
            DeathKnight, Druid, Hunter, Mage, Paladin, Priest, Rogue, Shaman, Warlock, Warrior
        }
        public enum Role
        {
            DPS, Heal, Tank
        }
    }
    
    public class Character
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z-\u00C0-\u00D6-\u00D8-\u00DD-\u00DF]+[a-z-\u00DF-\u00FF-\u00F8-\u00FD-\u00FF]{2,12}$", ErrorMessage = "Name has to start with upper case letter, continue with lower case letters and be between 2 and 12 Characters long.")]
        public string Name { get; set; }
        public ClassAndRole.Class Class { get; set; }
        public ClassAndRole.Role Role { get; set; }
        [Display(Name = "Raid Attendances")]
        public List<RaidAttendance> RaidAttendances { get; set; }
        [Display(Name = "Loot Infos")]
        public List<LootInfo> LootInfos { get; set; }
    }
}
