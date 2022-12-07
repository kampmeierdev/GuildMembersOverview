using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Data
{
    public class GuildMembersOverviewContext : DbContext
    {
        public GuildMembersOverviewContext (DbContextOptions<GuildMembersOverviewContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; } = default!;
        public DbSet<Character> Characters { get; set; } = default!;
        public DbSet<RaidAttendance> RaidAttendances { get; set; } = default!;
        public DbSet<LootInfo> LootInfos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<RaidAttendance>().ToTable("RaidAttendance");
            modelBuilder.Entity<LootInfo>().ToTable("LootInfo");
        }

    }
}
