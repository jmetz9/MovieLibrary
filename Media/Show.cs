using System;
using System.IO;

namespace MovieLibraryJoshM
{
    class Show : Media
    { 
        int id {get; set;}
        string title {get; set;}
        int season {get; set;}
        int episode {get; set;}
        string[] writers;
        public override void Display(){
            
        }
    }
}