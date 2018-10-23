using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> movies = new Dictionary<string, string>();
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();
            string command = "";
            int allFilmsDuration = 0;

            while ((command = Console.ReadLine()) != "POPCORN!")
            {
                string[] tokens = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string title = tokens[0];
                string filmGenre = tokens[1];
                string time = tokens[2];
                allFilmsDuration += CalculateDuration(time);
                if (filmGenre == genre)
                {
                    movies.Add(title, time);
                }
            }

            if (duration == "Short")
            {
                movies = movies.OrderBy(x => CalculateDuration(x.Value))
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);
            }
            else
            {
                movies = movies.OrderByDescending(x => CalculateDuration(x.Value))
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);
            }

            foreach (var movie in movies)
            {
                command = Console.ReadLine();
                if (command != "Yes")
                {
                    Console.WriteLine(movie.Key);
                }
                else
                {
                    Console.WriteLine(movie.Key);
                    Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                    break;
                }
            }

            string totalPlaylistTime = GetPlaylistTime(allFilmsDuration);
            Console.WriteLine($"Total Playlist Duration: {totalPlaylistTime}");
        }

        private static string GetPlaylistTime(int allFilmsDuration)
        {
            int hours = allFilmsDuration / 3600;
            int minutes = (allFilmsDuration % 3600) / 60;
            int seconds = allFilmsDuration % 60;
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        private static int CalculateDuration(string time)
        {
            string[] args = time.Split(':');
            int seconds = int.Parse(args[2]);
            int minutes = int.Parse(args[1]);
            int hours = int.Parse(args[0]);
            int totalMinutes = seconds + minutes * 60 + hours * 3600;

            return totalMinutes;
        }
    }
}
