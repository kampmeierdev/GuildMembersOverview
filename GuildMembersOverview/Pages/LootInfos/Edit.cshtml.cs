using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.LootInfos
{
    public class EditModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public EditModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LootInfo LootInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lootinfo =  await _context.LootInfos.FirstOrDefaultAsync(l => l.ID == id);
            if (lootinfo == null)
            {
                return NotFound();
            }

           LootInfo = lootinfo;
           ViewData["Character"] = new SelectList(_context.Characters, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var lootInfoToUpdate = await _context.LootInfos.FirstOrDefaultAsync(l => l.ID == id);

            if (lootInfoToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                lootInfoToUpdate,
                "looInfo",
                l => l.CharacterID, l => l.Item, l => l.Received))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
