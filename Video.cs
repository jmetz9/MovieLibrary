using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Video : Media
    {
        public string format {get; set;}
        public int length {get; set;}
        public int[] regions{get; set;}
        public override string Display()
        {
            return $"Id:{id} Title:{title} Format:{format} Length:{length} Writers:{string.Join(",", regions)}";
        }
    }
}