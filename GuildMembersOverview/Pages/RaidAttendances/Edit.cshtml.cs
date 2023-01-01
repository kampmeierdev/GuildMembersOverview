using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.RaidAttendances
{
    public class EditModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public EditModel(GuildMembersOverviewContext context)
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

            var raidAttendance = await _context.RaidAttendances.FirstOrDefaultAsync(r => r.ID == id);
            if (raidAttendance == null)
            {
                return NotFound();
            }
            RaidAttendance = raidAttendance;
            ViewData["Character"] = new SelectList(_context.Characters, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raidAttendanceToUpdate = await _context.RaidAttendances.FindAsync(id);

            if (raidAttendanceToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<RaidAttendance>(
                 raidAttendanceToUpdate,
                 "raidAttendance",
                 r => r.CharacterID, r => r.RaidDay, r => r.SignedUp, r => r.Attendance, r => r.AttendanceCount))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
