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
}