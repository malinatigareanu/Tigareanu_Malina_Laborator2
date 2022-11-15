using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tigareanu_Malina_Laborator2.Data;
using Tigareanu_Malina_Laborator2.Models;

namespace Tigareanu_Malina_Laborator2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Tigareanu_Malina_Laborator2.Data.Tigareanu_Malina_Laborator2Context _context;

        public DetailsModel(Tigareanu_Malina_Laborator2.Data.Tigareanu_Malina_Laborator2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
