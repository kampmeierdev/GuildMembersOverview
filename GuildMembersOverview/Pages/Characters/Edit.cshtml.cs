using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.Characters
{
    public class EditModel : PageModel
    {
        private readonly GuildMembersOverview.Data.GuildMembersOverviewContext _context;

        public EditModel(GuildMembersOverview.Data.GuildMembersOverviewContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Character Character { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Characters.FirstOrDefaultAsync(c => c.ID == id);

            if (Character == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var characterToUpdate = await _context.Characters.FirstOrDefaultAsync(c => c.ID == id);

            if (characterToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                characterToUpdate,
                "character",
                c => c.Name, c => c.Class, c => c.Role))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
