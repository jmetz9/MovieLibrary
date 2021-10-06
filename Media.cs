using System;
using System.IO;

namespace MovieLibraryJoshM
{
    abstract class Media
    { 
        public int id {get; set;}
        //string _title;
        public string title {
            get{
                return this.title;
            }
            set{
                this.title = value.IndexOf(',') != -1 ? $"\"{value}\"" : value;
            }
        }
        public abstract string Display();
    }
}