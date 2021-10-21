using System.Collections.Generic;

namespace MovieLibraryJoshM
{
    interface IManager<T> where T : Media
    {
        
        List<T> GetAllMedia();
        void AddMedia();
        void DisplayAllMedia();
        bool IsDuplicateTitle(string title);
        int GetLastId();
    
    }
}