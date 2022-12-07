using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildMembersOverview.Data;
using GuildMembersOverview.Models;

namespace GuildMembersOverview.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly GuildMembersOverview.Data.GuildMembersOverviewContext _context;

        public IndexModel(GuildMembersOverview.Data.GuildMembersOverviewContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Members != null)
            {
                Member = await _context.Members.ToListAsync();
            }
        }
    }
}
