using System;
using System.Collections.Generic;
using System.IO;
namespace MovieLibraryJoshM
{
    class ShowManager : MediaManager<Show>
    {
        public ShowManager()
        {
            Media = new List<Show>();
            file = "shows.csv";

            StreamReader sr = new StreamReader(file);
            // first line contains column headers
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // create instance of Movie class
                Show show = new Show();
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                    // no quote = no comma in movie title
                    // movie details are separated with comma(,)
                    string[] showDetails = line.Split(',');
                    show.id = int.Parse(showDetails[0]);
                    show.title = showDetails[1];
                    show.seasons = int.Parse(showDetails[2]);
                    show.episodes = int.Parse(showDetails[3]);
                    show.writers = showDetails[4].Split("|");

                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    show.id = int.Parse(line.Substring(0, idx - 1));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    show.title = line.Substring(0, idx);
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    string[] showDetails = line.Split(',');
                    show.seasons = int.Parse(showDetails[0]);
                    show.episodes = int.Parse(showDetails[1]);
                    show.writers = showDetails[2].Split('|');
                    }
                Media.Add(show);
            }
            // close file when done
            sr.Close();
        }

        public override void AddMedia()
        {
            int id = GetLastId() + 1;
            Console.WriteLine("Enter Show Title:");
            string title = Console.ReadLine();
            while (IsDuplicateTitle(title))
            {
                Console.WriteLine("Duplicate title, please retry.");
                title = Console.ReadLine();
            }
            Console.WriteLine("Enter Number of Seasons: ");
            int seasons;
            bool success = int.TryParse(Console.ReadLine(), out seasons);
            while(success == false){
                Console.WriteLine("Invalid input please try again");
                success = int.TryParse(Console.ReadLine(), out seasons);
            }
            Console.WriteLine("Enter Number of Episodes: ");
            int episodes;
            success = int.TryParse(Console.ReadLine(), out episodes);
            while(success == false){
                Console.WriteLine("Invalid input please try again");
                success = int.TryParse(Console.ReadLine(), out episodes);
            }

            string writer = "";
            string allWriters = "";
            do
            {
                Console.WriteLine("Enter A Writer");
                writer = Console.ReadLine();
                allWriters = allWriters + writer + "|";
                Console.WriteLine("Is there more writers?(Y/N)");
                string genreYN = Console.ReadLine().ToUpper();

                if (genreYN == "N")
                {
                    allWriters = allWriters.Remove(allWriters.LastIndexOf("|"));
                    break;
                }
            } while (true);

            Show show = new Show();
            show.id = id;
            show.title = title;
            show.seasons = seasons;
            show.episodes = episodes;
            show.writers = allWriters.Split("|");
            Media.Add(show);
            StreamWriter sw = new StreamWriter(file, true);
            //the only way I can get this to work properly is by having an empty line after the last line of movies.csv
            //so if that isn't there you can add it
            sw.WriteLine(id + "," + show.WrapInQuotes() + "," + seasons + "," + episodes + "," + allWriters);

            sw.Close();
        }
    }
}