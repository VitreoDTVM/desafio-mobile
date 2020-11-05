using HeroesApp.Models;
using System.Threading.Tasks;

namespace HeroesApp.Interfaces
{
    public interface IMarvelService
    {
        Task<BaseModel<CharacterModel>> GetCharacters();
        Task<BaseModel<CharacterModel>> GetCharacters(string filter);
        Task<BaseModel<CharacterModel>> GetCharacters(int offset);
        Task<BaseModel<ComicModel>> GetComicById(long characterId);
    }
}
