using GuildMembersOverview.Models;
using System.Diagnostics;

namespace GuildMembersOverview.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GuildMembersOverviewContext context)
        {
            // Look for any students.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var raidAttendances = new List<RaidAttendance>()
            {
                new RaidAttendance{ID=22, RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, AttendanceCount=1}
            };

            context.RaidAttendances.AddRange(raidAttendances);
            context.SaveChanges();

            var lootInfos = new List<LootInfo>()
            {
                new LootInfo{ID=33, Received=DateTime.UtcNow.Date, Item="TestItem"}
            };

            context.LootInfos.AddRange(lootInfos);
            context.SaveChanges();

            var characters = new List<Character>()
            {
                new Character{ID=11, Name="TestName", Class=ClassAndRole.Class.DeathKnight, Role=ClassAndRole.Role.Tank, RaidAttendanceList=raidAttendances, LootInfoList=lootInfos}
            };

            context.Characters.AddRange(characters);
            context.SaveChanges();

            var members = new Member[]
            {
                new Member{ID=1,  /*DiscordName="TestDiscordName",*/ Characters=characters, OverallRaidAttendance=1}
            };

            context.Members.AddRange(members);
            context.SaveChanges();
        }
    }
}