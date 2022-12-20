using GuildMembersOverview.Models;

namespace GuildMembersOverview.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GuildMembersOverviewContext context)
        {

            if (context.Characters.Any())
            {
                return;
            }

            var characters = new List<Character>()
            {
                new Character{Name="TestName", Class=ClassAndRole.Class.Druid, Role=ClassAndRole.Role.DPS},
                new Character{Name="TestName2", Class=ClassAndRole.Class.Paladin, Role=ClassAndRole.Role.Heal},
                new Character{Name="TestName3", Class=ClassAndRole.Class.DeathKnight, Role=ClassAndRole.Role.Tank},
                new Character{Name="TestName4", Class=ClassAndRole.Class.Warrior, Role=ClassAndRole.Role.Tank},
                new Character{Name="TestName5", Class=ClassAndRole.Class.Warrior, Role=ClassAndRole.Role.DPS},
                new Character{Name="TestName6", Class=ClassAndRole.Class.Warrior, Role=ClassAndRole.Role.DPS}
            };

            context.Characters.AddRange(characters);
            context.SaveChanges();

            var raidAttendances = new List<RaidAttendance>()
            {
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, AttendanceCount=3, CharacterID=1},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=false, AttendanceCount=2, CharacterID=2},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=false, Attendance=false, AttendanceCount=0, CharacterID=3},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, CharacterID=1},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, CharacterID=2},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=false, Attendance=false, CharacterID=3},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, CharacterID=1},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, CharacterID=2},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=false, CharacterID=3},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, AttendanceCount=1, CharacterID=4},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=true, Attendance=true, AttendanceCount=1, CharacterID=5},
                new RaidAttendance{RaidDay=DateTime.UtcNow.Date, SignedUp=false, Attendance=false, AttendanceCount=0, CharacterID=6}
            };

            context.RaidAttendances.AddRange(raidAttendances);
            context.SaveChanges();

            var lootInfos = new List<LootInfo>()
            {
                new LootInfo{Received=DateTime.UtcNow.Date, Item="TestItem", CharacterID=1},

            };

            context.LootInfos.AddRange(lootInfos);
            context.SaveChanges();

            
        }
    }
}