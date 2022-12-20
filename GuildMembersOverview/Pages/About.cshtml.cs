using GuildMembersOverview.Data;
using GuildMembersOverview.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GuildMembersOverview.Pages
{
    public class AboutModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;

        public AboutModel(GuildMembersOverviewContext context)
        {
            _context = context;
        }

        public IList<CountGroup> Counts { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<CountGroup> countGroupQueryable =
                from character in _context.Characters
                group character by new { character.Class, character.Role } into countGroup
                select new CountGroup()
                {
                    Class = (ClassAndRole.Class)countGroup.Key.Class,
                    Role = (ClassAndRole.Role)countGroup.Key.Role,
                    CharactersCount = countGroup.Count()
                };

            Counts = await countGroupQueryable.AsNoTracking().ToListAsync();
        }
    }
}
