using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoeeAmzaleg_HWS_Simple_CRUD.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieGenre { get; set; }
        public string MovieLenght { get; set; }

        public void MovieTypes(int movie)
        {
            switch (movie)
            {
                case 1:
                    MovieId = 1;
                    MovieName = "Spiderman";
                    MovieGenre = "Adventure";
                    MovieLenght = "120 Min";
                    Console.WriteLine(ToString());
                    Console.WriteLine();
                    break;
                case 2:
                    MovieId = 2;
                    MovieName = "James Bond";
                    MovieGenre = "Action";
                    MovieLenght = "132 Min";
                    Console.WriteLine(ToString());
                    Console.WriteLine();
                    break; 
                case 3:
                    MovieId = 3;
                    MovieName = "Matrix";
                    MovieGenre = "Sci-Fi";
                    MovieLenght = "115 Min";
                    Console.WriteLine(ToString());
                    Console.WriteLine();
                    break;
                default:
                    break;  
                    
            }
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
