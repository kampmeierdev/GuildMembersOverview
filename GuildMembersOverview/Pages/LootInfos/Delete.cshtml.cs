using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.LootInfos
{
    public class DeleteModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public DeleteModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LootInfo LootInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LootInfos == null)
            {
                return NotFound();
            }

            var lootinfo = await _context.LootInfos
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.ID == id);

            if (lootinfo == null)
            {
                return NotFound();
            }
            else 
            {
                LootInfo = lootinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LootInfos == null)
            {
                return NotFound();
            }
            var lootinfo = await _context.LootInfos.FindAsync(id);

            if (lootinfo != null)
            {
                LootInfo = lootinfo;
                _context.LootInfos.Remove(LootInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
