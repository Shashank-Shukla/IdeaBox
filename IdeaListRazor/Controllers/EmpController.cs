using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using IdeaListRazor.Model;

namespace BookListRazor.Controllers
{
    public class EmpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult OnGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OnPost(Emp ob)
        {
            return View();
        }
    }
}
