using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.RaidAttendances
{
    public class CreateModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public CreateModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Character"] = new SelectList(_context.Characters, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public RaidAttendance RaidAttendance { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRaidAttendance = new RaidAttendance();

            if (await TryUpdateModelAsync<RaidAttendance>(
                 emptyRaidAttendance,
                 "raidAttendance",
                 r => r.ID, r => r.CharacterID, r => r.RaidDay, r => r.SignedUp, r => r.Attendance, r => r.AttendanceCount))
            {
                _context.RaidAttendances.Add(emptyRaidAttendance);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
