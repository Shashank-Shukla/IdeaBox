using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdeaListRazor.Pages.Login
{
    public class LoginScreenModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public LoginScreenModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Emp Emps { get; set; }
        public void OnGet()
        {
        }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            return RedirectToPage("Index");
        }

    }
}
