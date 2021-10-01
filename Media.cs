using System;
using System.IO;

namespace MovieLibraryJoshM
{
    abstract class Media
    { 
        int id {get; set;}
        string title {get; set;}
        public abstract void Display();
    }
}