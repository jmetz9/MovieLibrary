using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Video : Media
    {
        string format {get; set;}
        int length {get; set;}
        int[] regions;
        public override void Display()
        {
            
        }
    }
}