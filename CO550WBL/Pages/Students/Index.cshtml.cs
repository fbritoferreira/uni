using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CO550WBL.Data;
using CO550WBL.Models;

namespace CO550WBL.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly CO550WBL.Data.ApplicationDbContext _context;

        public IndexModel(CO550WBL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.ToListAsync();
            }
        }
    }
}
