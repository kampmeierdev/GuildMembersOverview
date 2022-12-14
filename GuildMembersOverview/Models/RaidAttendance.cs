using System.ComponentModel.DataAnnotations;

namespace GuildMembersOverview.Models
{
    public class RaidAttendance
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime RaidDay { get; set; }
        public bool SignedUp { get; set; }
        public bool Attendance { get; set; }
        public int AttendanceCount { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}
