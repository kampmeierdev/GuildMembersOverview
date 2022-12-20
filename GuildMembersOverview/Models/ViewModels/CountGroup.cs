namespace GuildMembersOverview.Models.ViewModels
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

    public class CountGroup
    {
        public ClassAndRole.Class Class { get; set; }
        public ClassAndRole.Role Role { get; set; }
        public int CharactersCount { get; set; }
    }
}
