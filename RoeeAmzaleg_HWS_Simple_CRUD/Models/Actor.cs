using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoeeAmzaleg_HWS_Simple_CRUD.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public int ActorAge { get; set; }
        private Movie Movie { get; set; }
        private MovieContext Context { get; set; }
        //public Actor()
        //{
        //    Context = new();
        //}
        //public Actor(string actorName, int actorAge, Movie movie)
        //{
        //    ActorName=actorName;
        //    ActorAge=actorAge;
        //    Movie=movie;
        //}
        public void ActorDetalis(int actor)
        {
            switch (actor)
            {
                case 1:
                    ActorId = 1;
                    ActorName = "Tobey Maguire";
                    ActorAge = 46;
                    Console.WriteLine(ToString());
                    Console.WriteLine();
                    break;
                case 2:
                    ActorId = 2;
                    ActorName = "Daniel Craig";
                    ActorAge = 54;
                    Console.WriteLine(ToString());
                    Console.WriteLine();
                    break;
                case 3:
                    ActorId = 2;
                    ActorName = "Keanu Reeves";
                    ActorAge = 57;
                    Console.WriteLine(ToString());
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }
        public void AddToDataBase()
        {
            var Context = new MovieContext();

            Context.SaveChanges();
            while (true)
            {
                Console.WriteLine("please select a movie: 1-Spiderman, 2-James Bond, 3-Matrix");
                string? moviePick = Console.ReadLine();

                Movie movie = new Movie();
                Actor actor = new Actor();
                if (moviePick != null)
                {
                    switch (moviePick)
                    {
                        case "1":
                            Console.WriteLine($"you have seleted:Spiderman\n");
                            movie.MovieTypes(1);
                            actor.ActorDetalis(1);
                            break;
                        case "2":
                            Console.WriteLine("you have seleted:James Bond\n");
                            movie.MovieTypes(2);
                            actor.ActorDetalis(2);

                            break;
                        case "3":
                            Console.WriteLine("you have seleted:Matrix\n");
                            movie.MovieTypes(3);
                            actor.ActorDetalis(3);
                            break;
                        default:
                            Console.WriteLine("you need to select a number between 1-3");
                            break;

                            Context.Actors.Add(actor);
                            Context.Movies.Add(movie);
                            Context.SaveChanges();
                            break;
                    }
                    break;
                }
            }
        }
        public void RemoveFromDataBase()
        {
            Console.WriteLine("Please Enter ID Of The Actor You Would Like To Delete:");
            int actorId = int.Parse(Console.ReadLine());
            using (var DeleteActor = new MovieContext())
            {
                if (actorId > 0)
                {
                    DeleteActor.Remove(DeleteActor.Actors.Single(x => x.ActorId == actorId));
                }
                else
                {
                    Console.WriteLine("Id Not Exist !");
                }
                DeleteActor.SaveChanges();
            }

            Console.WriteLine("Please Enter ID Of The Movie You Would Like To Delete:");
            int movieId = int.Parse(Console.ReadLine());
            using (var DeleteMovie = new MovieContext())
            {
                if (movieId > 0)
                {
                    DeleteMovie.Remove(DeleteMovie.Movies.Single(x => x.MovieId == movieId));
                }
                else
                {
                    Console.WriteLine("Id Not Exist !");
                }
                DeleteMovie.SaveChanges();
            }
            Console.WriteLine(" Your Data Has Been Deleted! ");

        }

        public void UpdateDataBase()
        {

            while (true)
            {
                Console.WriteLine("please select a movie id you like to update:");
                string id = Console.ReadLine();
                int update = Convert.ToInt32(id);
                var record = Context.Movies.FirstOrDefault(x => x.MovieId == update);
                if (record != null)
                {
                    try
                    {
                        Console.WriteLine("please enter new movie name:\n");
                        record.MovieName = Console.ReadLine();

                        Console.WriteLine("please enter the movie genre:\n");
                        record.MovieGenre = Console.ReadLine();

                        Console.WriteLine("please enter the movie lenght:\n");
                        record.MovieLenght = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("id not found!");
                        continue;
                    }
                    Context.SaveChanges();
                    break;
                }
            }
        }
        public void GetDataBaseRecords()
        {
            Console.WriteLine("please pick a movie id to get details or type 0 to see all:");
            string s = Console.ReadLine();
            if (s != null)
            {
                int id = Convert.ToInt32(s);
                var details = Context.Movies.SingleOrDefault(x => x.MovieId == id);
                switch (id)
                {
                    case 0:
                        {
                            foreach (var item in Context.Movies)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(details);
                            break;
                        }
                }
            }
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
