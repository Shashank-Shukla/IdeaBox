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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Idea Idea { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Idea = new Idea();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Idea = await _db.Idea.FirstOrDefaultAsync(u => u.Id == id);
            if (Idea == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Idea.Id == 0)
                {
                    _db.Idea.Add(Idea);
                }
                else
                {
                    _db.Idea.Update(Idea);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}