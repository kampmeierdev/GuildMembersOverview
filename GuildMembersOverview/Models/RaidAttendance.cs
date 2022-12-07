namespace GuildMembersOverview.Models
{
    public class RaidAttendance
    {
        public int ID { get; set; }
        public DateTime RaidDay { get; set; }
        public bool SignedUp { get; set; }
        public bool Attendance { get; set; }
        public int AttendanceCount { get; set; }
    }
}
