using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.Characters
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
            return Page();
        }

        [BindProperty]
        public Character Character { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCharacter = new Character();

            if (await TryUpdateModelAsync(
                emptyCharacter,
                "character",
                c => c.Name, c => c.Class, c => c.Role))
            {
                _context.Characters.Add(emptyCharacter);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
