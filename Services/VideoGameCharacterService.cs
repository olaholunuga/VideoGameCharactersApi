using NewApi.Data;
using NewApi.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Character>> GetAllCharactersAsync()
        => await context.Characters.ToListAsync();
    
    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        // var character = characters.FirstOrDefault(c => c.Id == id);
        return await context.Characters.FindAsync(id);
    }
    
    public async Task<Character> AddCharacterAsync(Character character)
        => throw new NotImplementedException();
    
    public async Task<Character> UpdateCharacterAsync(int id, Character character)
        => throw new NotImplementedException();
    
    public async Task<bool> DeleteCharacterAsync(int id)
        => throw new NotImplementedException();
}