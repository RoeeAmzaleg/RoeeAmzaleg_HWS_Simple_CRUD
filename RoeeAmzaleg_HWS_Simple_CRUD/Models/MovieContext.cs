using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoeeAmzaleg_HWS_Simple_CRUD.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HPSPECTRE;Database=MoviesDB;Trusted_Connection=True;");
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
