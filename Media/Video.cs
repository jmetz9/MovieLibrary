using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Video : Media
    {
        int id {get; set;}
        string title {get; set;}
        string format {get; set;}
        int length {get; set;}
        int[] regions;
        public override void Display()
        {
            
        }
    }
}