namespace GuildMembersOverview.Models
{
    public class Member
    {
        public int ID { get; set; }
        //public string DiscordName { get; set; }
        //public int CharacterID { get; set; }
        public List<Character> Characters { get; set; }
        public int OverallRaidAttendance { get; set; }
    }
}
