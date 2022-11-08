using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tigareanu_Malina_Laborator2.Data;
using Tigareanu_Malina_Laborator2.Models;

namespace Tigareanu_Malina_Laborator2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Tigareanu_Malina_Laborator2.Data.Tigareanu_Malina_Laborator2Context _context;

        public IndexModel(Tigareanu_Malina_Laborator2.Data.Tigareanu_Malina_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
