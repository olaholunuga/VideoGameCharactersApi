using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NewApi.Models;
using NewApi.Services;
using NewApi.Dtos;

[ApiController]
[Route("api/[Controller]")]
public class VideoGameCharactersController(IVideoGameGameCharacterService service) : ControllerBase()
{
    [HttpGet]
    public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
        => Ok(await service.GetAllCharactersAsync());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterResponse?>> GetCharacter(int id)
    {
        var character = await service.GetCharacterByIdAsync(id);
        return character is null ? NotFound("Character with the given ID is not found") : Ok(character);
        // if (character is null)
        // {
        //     return NotFound("Character with the given ID is not found");
        // }
        // return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
    {
        var createdCharacter = await service.AddCharacterAsync(character);
        return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CharacterResponse>> UpdateCharacter(int id, UpdateCharacterRequest character)
    {
        var updatedCharacter = await service.UpdateCharacterAsync(id, character);
        return updatedCharacter is not null ? Ok(updatedCharacter) : NotFound("Character with the given ID not found");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCharacter(int id)
    {
        var deleted = await service.DeleteCharacterAsync(id);
        return deleted ? NoContent() : NotFound("Character with the given ID not found");
    }
}