using IdeaListRazor.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaListRazor.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _uM;
        private readonly SignInManager<IdentityUser> _siM;
        public LoginController(ApplicationDbContext db, UserManager<IdentityUser> uM, SignInManager<IdentityUser> siM)
        {
            _db = db;
            _uM = uM;
            _siM = siM;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LoginScreen()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginScreen(Emp model)
        {
            if (ModelState.IsValid)
            {
                var res = await _siM.PasswordSignInAsync(model.EmpName, model.PassWd, false, false);
                if (res.Succeeded)
                {
                    return RedirectToPage("_layout");
                }
                ModelState.AddModelError(string.Empty, "Invalid Credentials");
            }
            return View(model);
        }
    }
}
