using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdeaListRazor.Pages.IdeaList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Idea> Ideas { get; set; }

        public async Task OnGet()
        {
            Ideas = await _db.Idea.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Idea = await _db.Idea.FindAsync(id);
            if (Idea == null)
            {
                return NotFound();
            }
            _db.Idea.Remove(Idea);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}