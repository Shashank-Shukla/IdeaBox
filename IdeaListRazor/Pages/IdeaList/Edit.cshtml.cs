using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdeaListRazor.Pages.IdeaList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Idea Idea { get; set; }

        public async Task OnGet(int id)
        {
            Idea = await _db.Idea.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var IdeaFromDb = await _db.Idea.FindAsync(Idea.Id);
                IdeaFromDb.IdeaText = Idea.IdeaText;
                IdeaFromDb.Tag = Idea.Tag;
                IdeaFromDb.Author = Idea.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}