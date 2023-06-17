using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Models;

namespace StudentCRUD.Pages.StudentList
{
    public class IndexModel : PageModel
    {
        private readonly StudentContext _db;

        public IndexModel(StudentContext db)
        {
            _db = db;
        }

        public IEnumerable<Student> Students { get; set; }

        public async Task OnGet()
        {
            Students = await _db.Students.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        
    }
}
