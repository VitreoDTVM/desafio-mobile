using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MVitreo.Models;

namespace MVitreo.Services.Interfaces
{
    
        public interface IMarvelService
        {
            Task<ObservableCollection<Character>> GetCharactersAsync(string value);
        }
   
}
