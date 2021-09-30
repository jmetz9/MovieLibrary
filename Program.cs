using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "movies.csv";
            string choice;
            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Add a movie to the file.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
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
                    

                    Console.WriteLine("Enter Movie Title:");
                    string title = Console.ReadLine();
                    while (CompareTitle(title))
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
                            break;
                        }
                    } while (true);
                    int id = GetLastId() + 1;
                    //need to fix: appends to end of line not making a new line underneath
                    StreamWriter sw = File.AppendText(file);
                    sw.WriteLine(id + "," + title + "," + allGenres);
                    sw.Close();

                }
            } while (choice == "1" || choice == "2");
        }

        public static int GetLastId()
        {

            string file = "movies.csv";
            StreamReader sr = new StreamReader(file);
            string id = "0";

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                id = line.Substring(0, line.IndexOf(","));
            }
            sr.Close();
            return Convert.ToInt32(id);
        }

        public static bool CompareTitle(string title)
        {
            string file = "movies.csv";
            StreamReader sr = new StreamReader(file);
            bool duplicate = false;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                //need to fix: looks at entire line not just the title
                if (line.Contains(title))
                {
                    duplicate = true;
                }
            }
            sr.Close();
            return duplicate;
        }
    }
}
