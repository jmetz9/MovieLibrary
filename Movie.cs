using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Movie : Media
    {
        string[] genres{get; set;}
        public override string Display()
        {
            return $"Id:{id} Title:{title} Genres:{string.Join(", ", genres)}\n";
        }
    }
}