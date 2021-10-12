using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Show : Media
    {
        public int seasons { get; set; }
        public int episodes { get; set; }
        public string[] writers{get; set;}
        public override string Display()
        {
            return $"Id:{id} Title:{title} Seasons:{seasons} Episodes:{episodes} Writers:{string.Join("|", writers)}";
        }
    }
}