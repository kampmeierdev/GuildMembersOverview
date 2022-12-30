using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.LootInfos
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
        public LootInfo LootInfo { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyLootInfo = new LootInfo();

            if (await TryUpdateModelAsync(
                 emptyLootInfo,
                 "lootInfo",
                 l => l.CharacterID, l => l.Item, l => l.Received))
            {
                _context.LootInfos.Add(emptyLootInfo);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
