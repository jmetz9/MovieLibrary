using System;

namespace Assignment3_A4_JoshM
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "movies.csv";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Add a movie to the file.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            //display data
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    //ask for title
                    Console.WriteLine("Enter Movie Title:");
                    string title = Console.ReadLine();
                    //ask for genres
                    do
                    {
                        string allGenres = "";
                        Console.WriteLine("Enter Movie Genre");
                        string genre = Console.ReadLine();
                        allGenres = allGenres + genre + "|";
                        Console.WriteLine("Is there more genres?(Y/N)");
                        string genreYN = Console.ReadLine();
                        if(genreYN == "N"){
                            break;
                        }
                    } while(true);
                    //int id = the id of the last movie in the list + 1
                    //append to the next line: id + "," + title + "," + allGenres
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
