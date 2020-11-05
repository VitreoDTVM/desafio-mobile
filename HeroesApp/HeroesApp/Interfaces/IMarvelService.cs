using HeroesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesApp.Interfaces
{
    public interface IMarvelService
    {
        Task<BaseModel<CharacterModel>> GetCharacters();
        Task GetCharactersById(long id);
    }
}
