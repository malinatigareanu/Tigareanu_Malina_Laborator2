using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tigareanu_Malina_Laborator2.Models;

namespace Tigareanu_Malina_Laborator2.Data
{
    public class Tigareanu_Malina_Laborator2Context : DbContext
    {
        public Tigareanu_Malina_Laborator2Context (DbContextOptions<Tigareanu_Malina_Laborator2Context> options)
            : base(options)
        {
        }

        public DbSet<Tigareanu_Malina_Laborator2.Models.Book> Book { get; set; } = default!;

        public DbSet<Tigareanu_Malina_Laborator2.Models.Publisher> Publisher { get; set; }

        public DbSet<Tigareanu_Malina_Laborator2.Models.Author> Author { get; set; }
    }
}
