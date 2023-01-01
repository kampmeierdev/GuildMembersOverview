using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.RaidAttendances
{
    public class DeleteModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public DeleteModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RaidAttendance RaidAttendance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raidattendance = await _context.RaidAttendances
                .Include(l => l.Character)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (raidattendance == null)
            {
                return NotFound();
            }
            else 
            {
                RaidAttendance = raidattendance;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RaidAttendances == null)
            {
                return NotFound();
            }
            var raidattendance = await _context.RaidAttendances.FindAsync(id);

            if (raidattendance != null)
            {
                RaidAttendance = raidattendance;
                _context.RaidAttendances.Remove(RaidAttendance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
