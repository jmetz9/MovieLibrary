using System;
using System.Collections.Generic;
using System.IO;
namespace MovieLibraryJoshM
{
    class VideoManager : MediaManager<Video>
    {
        public VideoManager()
        {
            Media = new List<Video>();
            file = "videos.csv";

            StreamReader sr = new StreamReader(file);
            // first line contains column headers
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // create instance of Movie class
                Video video = new Video();
                string line = sr.ReadLine();
                // first look for quote(") in string
                // this indicates a comma(,) in movie title
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                    // no quote = no comma in movie title
                    // movie details are separated with comma(,)
                    string[] videoDetails = line.Split(',');
                    video.id = int.Parse(videoDetails[0]);
                    video.title = videoDetails[1];
                    video.format = videoDetails[2];
                    video.length = int.Parse(videoDetails[3]);
                    video.regions = Array.ConvertAll(videoDetails[4].Split('|'), s => int.Parse(s));
                }
                else
                {
                    // quote = comma in movie title
                    // extract the movieId
                    video.id = int.Parse(line.Substring(0, idx - 1));
                    // remove movieId and first quote from string
                    line = line.Substring(idx + 1);
                    // find the next quote
                    idx = line.IndexOf('"');
                    // extract the movieTitle
                    video.title = line.Substring(0, idx);
                    // remove title and last comma from the string
                    line = line.Substring(idx + 2);
                    string[] videoDetails = line.Split(',');
                    video.format = videoDetails[0];
                    video.length = int.Parse(videoDetails[1]);
                    video.regions = Array.ConvertAll(videoDetails[2].Split('|'), s => int.Parse(s));
                    }
                Media.Add(video);
            }
            // close file when done
            sr.Close();
        }

        public override void AddMedia()
        {
            int id = GetLastId() + 1;
            Console.WriteLine("Enter Video Title:");
            string title = Console.ReadLine();
            while (IsDuplicateTitle(title))
            {
                Console.WriteLine("Duplicate title, please retry.");
                title = Console.ReadLine();
            }
            Console.WriteLine("Enter Format:");
            string format = Console.ReadLine();
            Console.WriteLine("Enter Length: ");
            int length;
            bool success = int.TryParse(Console.ReadLine(), out length);
            while(success == false){
                Console.WriteLine("Invalid input please try again");
                success = int.TryParse(Console.ReadLine(), out length);
            }

            string region = "";
            string allRegions = "";
            do
            {
                Console.WriteLine("Enter Region #");
                region = Console.ReadLine();
                allRegions = allRegions + region + "|";
                Console.WriteLine("Is there more regions?(Y/N)");
                string genreYN = Console.ReadLine().ToUpper();

                if (genreYN == "N")
                {
                    allRegions = allRegions.Remove(allRegions.LastIndexOf("|"));
                    break;
                }
            } while (true);


            Video video = new Video();
            video.id = id;
            video.title = title;
            video.format = format;
            video.length = length;
            video.regions = Array.ConvertAll(allRegions.Split('|'), s => int.Parse(s));
            Media.Add(video);
            StreamWriter sw = new StreamWriter(file, true);
            //the only way I can get this to work properly is by having an empty line after the last line of movies.csv
            //so if that isn't there you can add it
            sw.WriteLine(id + "," + video.WrapInQuotes() + "," + format + "," + length + "," + allRegions);

            sw.Close();
        }
    }
}