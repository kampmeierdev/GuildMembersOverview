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
            Tank, Heal, DPS
        }
    }
    
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ClassAndRole.Class Class { get; set; }
        public ClassAndRole.Role Role { get; set; }
        public List<RaidAttendance> RaidAttendances { get; set; }
        public List<LootInfo> LootInfos { get; set; }
    }
}
