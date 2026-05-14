using NewApi.Data;
using NewApi.Models;
using Microsoft.EntityFrameworkCore;
using NewApi.Dtos;

namespace NewApi.Services;

public class VideoGameCharacterService(AppDbContext context) : IVideoGameGameCharacterService
{
    static List<Character> characters = new List<Character>
    {
        new Character { Id = 1, Game = "Super Mario Bros", Name = "Mario", Role = "Hero"},
        new Character { Id = 2, Name = "Link", Game = "Legend of Zelda", Role = "Hero"},
        new Character { Id = 3, Name = "Bowser", Game = "Super Mario Bros", Role = "Villian"},
        new Character { Id = 4, Name = "Zelda", Game = "Legend of Zelda", Role = "Princess"}
    
    };

    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
        => await context.Characters.Select(c => new CharacterResponse
        {
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).ToListAsync();
    
    public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
    {
        // var character = characters.FirstOrDefault(c => c.Id == id);
        return await context.Characters
        .Where(c => c.Id == id)
        .Select(c => new CharacterResponse
        {
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).FirstOrDefaultAsync();
    }
    
    public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        => throw new NotImplementedException();
    
    public async Task<CharacterResponse> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        => throw new NotImplementedException();
    
    public async Task<bool> DeleteCharacterAsync(int id)
        => throw new NotImplementedException();
}