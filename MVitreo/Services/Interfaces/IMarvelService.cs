using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVitreo.Models;

namespace MVitreo.Services.Interfaces
{
    
        public interface IMarvelService
        {
            Task<List<Character>> GetCharactersAsync(string value);
        }
   
}
