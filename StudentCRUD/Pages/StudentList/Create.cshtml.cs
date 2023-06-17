using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRUD.Models;

namespace StudentCRUD.Pages.StudentList
{
    public class CreateModel : PageModel
    {
        private readonly StudentContext _db;

        public CreateModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Students { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Students.AddAsync(Students);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
