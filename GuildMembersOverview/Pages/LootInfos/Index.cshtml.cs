using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.LootInfos
{
    public class IndexModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public IndexModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

        public IList<LootInfo> LootInfos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LootInfos = await _context.LootInfos
                .Include(l => l.Character)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
