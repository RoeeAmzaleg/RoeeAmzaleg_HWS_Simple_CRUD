using Microsoft.EntityFrameworkCore;
using RoeeAmzaleg_HWS_Simple_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoeeAmzaleg_HWS_Simple_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Actor context = new Actor();
            while (true)
            {
                Console.WriteLine("please select an option:\n");
                Console.WriteLine("1 - Add Movie");
                Console.WriteLine("2 - Remove a movie");
                Console.WriteLine("3 - Update movie");
                Console.WriteLine("4 - Get movie details");
                Console.WriteLine("5 - Quit\n");

                string? input = Console.ReadLine();
                if (input != null)
                {
                    switch (input)
                    {
                        case "1":
                            context.AddToDataBase();
                            break;
                        case "2":
                            context.RemoveFromDataBase();
                            break;
                        case "3":
                            context.UpdateDataBase();
                            break;
                        case "4":
                            context.GetDataBaseRecords();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Wrong number. \n");
                            continue;

                    }

                }

            }
        }
    }
}
