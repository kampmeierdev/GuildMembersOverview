using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.Characters
{
    public class DetailsModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public DetailsModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

      public Character Character { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.RaidAttendances)
                .Include(c => c.LootInfos)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ID == id);

            if (character == null)
            {
                return NotFound();
            }
            else 
            {
                Character = character;
            }
            return Page();
        }
    }
}
