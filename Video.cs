using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Video : Media
    {
        string format {get; set;}
        int length {get; set;}
        int[] regions{get; set;}
        public override string Display()
        {
            return $"Id:{id} Title:{title} Format:{format} Length:{length} Writers:{string.Join(", ", regions)}\n";
        }
    }
}