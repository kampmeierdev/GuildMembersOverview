using GuildMembersOverview.Models;
using System.Diagnostics;

namespace GuildMembersOverview.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GuildMembersOverviewContext context)
        {
            // Look for any students.
            if (context.Characters.Any())
            {
                return;   // DB has been seeded
            }

            var characters = new List<Character>()
            {
                new Character{Name="TestName", Class=ClassAndRole.Class.Druid, Role=ClassAndRole.Role.DPS}
            };

            context.Characters.AddRange(characters);
            context.SaveChanges();

            var raidAttendances = new List<RaidAttendance>()
            {
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, AttendanceCount=1, CharacterID=1}
            };

            context.RaidAttendances.AddRange(raidAttendances);
            context.SaveChanges();

            var lootInfos = new List<LootInfo>()
            {
                new LootInfo{Received=DateTime.UtcNow.Date, Item="TestItem", CharacterID=1}
            };

            context.LootInfos.AddRange(lootInfos);
            context.SaveChanges();

            
        }
    }
}