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
    public class UpsertModel : PageModel
    {
        private StudentContext _db;

        public UpsertModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Students { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Students = new Student();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Students = await _db.Students.FirstOrDefaultAsync(u => u.ID == id);
            if (Students == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Students.ID == 0)
                {
                    _db.Students.Add(Students);
                }
                else
                {
                    _db.Students.Update(Students);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}
