using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Show : Media
    {
        int season { get; set; }
        int episode { get; set; }
        string[] writers{get; set;}
        public override string Display()
        {
            return $"Id:{id} Title:{title} Seasons:{season} Episodes:{episode} Writers:{string.Join(", ", writers)}\n";
        }
    }
}