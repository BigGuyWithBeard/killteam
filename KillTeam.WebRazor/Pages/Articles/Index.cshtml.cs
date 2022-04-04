using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KillTeam.WebRazor.Models;

namespace KillTeam.WebRazor.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly KillTeam.WebRazor.KillTeamDbContext _context;

        public IndexModel(KillTeam.WebRazor.KillTeamDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article.ToListAsync();
        }
    }
}
