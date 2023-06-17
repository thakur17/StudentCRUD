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
    public class DetailsModel : PageModel
    {
        private readonly StudentContext _db;

        public DetailsModel(StudentContext db)
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


    }
}
