﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tigareanu_Malina_Laborator2.Data;
using Tigareanu_Malina_Laborator2.Models;
using Tigareanu_Malina_Laborator2.Models.ViewModels;

namespace Tigareanu_Malina_Laborator2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Tigareanu_Malina_Laborator2.Data.Tigareanu_Malina_Laborator2Context _context;

        public IndexModel(Tigareanu_Malina_Laborator2.Data.Tigareanu_Malina_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? BookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Book)
            .ThenInclude(i => i.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;
            }
        }
    }
}
