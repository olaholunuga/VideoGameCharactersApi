using NewApi.Dtos;
using NewApi.Models;
namespace NewApi.Services;

public interface IVideoGameGameCharacterService
{
    Task<List<CharacterResponse>> GetAllCharactersAsync();
    Task<CharacterResponse?> GetCharacterByIdAsync(int id);
    Task<CharacterResponse> AddCharacterAsync(Character character);
    Task<CharacterResponse> UpdateCharacterAsync(int id, Character character);
    Task<bool> DeleteCharacterAsync(int id);
}