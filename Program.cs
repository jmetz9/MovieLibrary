using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            MediaManager<Movie> movieMan = new MovieManager();
            MediaManager<Show> showMan = new ShowManager();
            MediaManager<Video> videoMan = new VideoManager();
            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Add a media to the file.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Which type of media? (M)ovie, (S)how, (V)ideo");
                    choice = Console.ReadLine();
                    switch(choice.ToLower()){
                        case "m" :
                        movieMan.DisplayAllMedia();

                        break;

                        case "s" :
                        showMan.DisplayAllMedia();

                        break;

                        case "v" :
                        videoMan.DisplayAllMedia();

                        break; 
                    }
                    
                    
                }
                else if (choice == "2")
                {

                    Console.WriteLine("Which type of media? (M)ovie, (S)how, (V)ideo");
                    choice = Console.ReadLine();
                    switch(choice.ToLower()){
                        case "m" :
                        movieMan.AddMedia();

                        break;

                        case "s" :
                        showMan.AddMedia();

                        break;

                        case "v" :
                        videoMan.AddMedia();

                        break; 
                    }
                }
                Console.WriteLine("Anything else? N/Y");
                choice = Console.ReadLine();
            } while (choice.ToLower() == "y");
        }

    }
}
