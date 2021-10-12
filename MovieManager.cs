using System;
using System.Collections.Generic;
using System.IO;
namespace MovieLibraryJoshM
{
    class MovieManager : MediaManager<Movie>
    {
        public MovieManager()
        {
            Media = new List<Movie>();
            file = "movies.csv";

            StreamReader sr = new StreamReader(file);
            // first line contains column headers
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // create instance of Movie class
                Movie movie = new Movie();
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                    // no quote = no comma in movie title
                    // movie details are separated with comma(,)
                    string[] movieDetails = line.Split(',');
                    movie.id = int.Parse(movieDetails[0]);
                    movie.title = movieDetails[1];
                    movie.genres = movieDetails[2].Split('|');
                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    movie.id = int.Parse(line.Substring(0, idx - 1));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    movie.title = line.Substring(0, idx);
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    // replace the "|" with ", "
                    movie.genres = line.Split('|');
                }
                Media.Add(movie);
            }
            // close file when done
            sr.Close();
        }

        public override void AddMedia()
        {
            int id = GetLastId() + 1;
            Console.WriteLine("Enter Movie Title:");
            string title = Console.ReadLine();
            while (IsDuplicateTitle(title))
            {
                Console.WriteLine("Duplicate title, please retry.");
                title = Console.ReadLine();
            }


            string genre = "";
            string allGenres = "";
            do
            {
                Console.WriteLine("Enter Movie Genre");
                genre = Console.ReadLine();
                allGenres = allGenres + genre + "|";
                Console.WriteLine("Is there more genres?(Y/N)");
                string genreYN = Console.ReadLine().ToUpper();

                if (genreYN == "N")
                {
                    allGenres = allGenres.Remove(allGenres.LastIndexOf("|"));
                    break;
                }
            } while (true);

            Movie movie = new Movie();
            movie.id = id;
            movie.title = title;
            movie.genres = allGenres.Split('|');
            Media.Add(movie);
            StreamWriter sw = new StreamWriter(file, true);
            //the only way I can get this to work properly is by having an empty line after the last line of movies.csv
            //so if that isn't there you can add it
            sw.WriteLine(id + "," + movie.WrapInQuotes() + "," + allGenres);

            sw.Close();
        }
    }
}