using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaListRazor.Controllers
{
    [Route("api/Idea")]
    [ApiController]
    public class IdeaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IdeaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _db.Idea.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var IdeaFromDb = await _db.Idea.FirstOrDefaultAsync(u => u.Id == id);
            if (IdeaFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Idea.Remove(IdeaFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}