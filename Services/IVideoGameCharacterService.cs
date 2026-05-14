using NewApi.Models;
namespace NewApi.Services;

public interface IVideoGameGameCharacterService
{
    Task<List<Character>> GetAllCharactersAsync();
    Task<Character?> GetCharacterByIdAsync(int id);
    Task<Character> AddCharacterAsync(Character character);
    Task<Character> UpdateCharacterAsync(int id, Character character);
    Task<bool> DeleteCharacterAsync(int id);
}