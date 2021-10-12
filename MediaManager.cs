using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibraryJoshM
{
    abstract class MediaManager<T> where T : Media
    { 
        public string file;
        public List<T> Media {get; set;}
        public List<T> GetAllMedia(){
            List<T> mediaList = new List<T>();
            foreach (T media in Media)
            {
                mediaList.Add(media);
            }
            return mediaList;
        }
        public abstract void AddMedia();

        public void DisplayAllMedia(){
            int i = 1;
            string choice;
            
            foreach (T media in Media)
            {
                if(i % 50 == 0){
                    Console.Write("press E to end. press anything else to continue: ");
                    choice = Console.ReadLine();
                    if(choice.ToLower() == "e"){
                        break;
                    }
                }
                Console.WriteLine(media.Display());
                i++;
            }
        }

        public bool IsDuplicateTitle(string title)
        {
            bool duplicate = false;

            foreach (T media in Media)
            {
                if(media.title == title){
                    duplicate = true;
                }
            }

            return duplicate;
        }

        public int GetLastId()
        {

            return Media.Max(m => m.id);

        }
    }
}