using System;
using System.IO;

namespace MovieLibraryJoshM
{
    abstract class Media
    { 
        public int id {get; set;}
        public string title {get; set;}
        public abstract string Display();

        public string WrapInQuotes(){
            return title.IndexOf(',') != -1 ? $"\"{title}\"" : title;
        }
    }
}