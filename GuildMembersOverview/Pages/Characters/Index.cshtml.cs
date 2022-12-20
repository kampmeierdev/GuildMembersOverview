using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.Characters
{
    public class IndexModel : PageModel
    {
        private readonly GuildMembersOverviewContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(GuildMembersOverviewContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string ClassSort { get; set; }
        public string RoleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Character> Characters { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ClassSort = sortOrder == "Class" ? "class_desc" : "Class";
            RoleSort = sortOrder == "Role" ? "role_desc" : "Role";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Character> charactersQuery = from c in _context.Characters select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                charactersQuery = charactersQuery.Where(c => c.Name.Contains(searchString));
            }

            charactersQuery = sortOrder switch
            {
                "name_desc" => charactersQuery.OrderByDescending(c => c.Name),
                "Class" => charactersQuery.OrderBy(c => c.Class),
                "class_desc" => charactersQuery.OrderByDescending(c => c.Class),
                "Role" => charactersQuery.OrderBy(c => c.Role),
                "role_desc" => charactersQuery.OrderByDescending(c => c.Role),
                _ => charactersQuery.OrderBy(c => c.Name),
            };

            var pageSize = Configuration.GetValue("PageSize", 4);
            Characters = await PaginatedList<Character>.CreateAsync(
                charactersQuery.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
