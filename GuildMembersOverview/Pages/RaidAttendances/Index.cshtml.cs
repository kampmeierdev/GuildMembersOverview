using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.RaidAttendances
{
    public class IndexModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public IndexModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

        public IList<RaidAttendance> RaidAttendances { get;set; }

        public async Task OnGetAsync()
        {
            RaidAttendances = await _context.RaidAttendances
                .Include(r => r.Character)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
