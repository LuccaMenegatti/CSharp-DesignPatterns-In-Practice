using AtividadeEmGrupoP2.Domain.Dtos.Request;
using AtividadeEmGrupoP2.Domain.UseCases.FootballPlayers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeEmGrupoP2.Api.Controllers;

[ApiController]
[Route("football_players")]
public class FootballPlayerController(
    ICreatePlayerUseCase createPlayerUseCase,
    IUpdatePlayerUseCase updatePlayerUseCase,
    IDeletePlayerUseCase deletePlayerUseCase,
    IGetPlayersUseCase getPlayersUseCase,
    IGetPlayerByIdUseCase getPlayerByIdUseCase) : ControllerBase
{
    private readonly ICreatePlayerUseCase _createPlayerUseCase = createPlayerUseCase;
    private readonly IUpdatePlayerUseCase _updatePlayerUseCase = updatePlayerUseCase;
    private readonly IDeletePlayerUseCase _deletePlayerUseCase = deletePlayerUseCase;
    private readonly IGetPlayersUseCase _getPlayersUseCase = getPlayersUseCase;
    private readonly IGetPlayerByIdUseCase _getPlayerByIdUseCase = getPlayerByIdUseCase;


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreatePlayerAsync([FromBody] CreateFootballPlayerRequest request, CancellationToken ct)
    {
        var response = await _createPlayerUseCase.CreateAsync(request, ct);
        return Created(nameof(CreatePlayerAsync), response);
    }

    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdatePlayerAsync(Guid id, [FromBody] UpdateFootballPlayerRequest request, CancellationToken ct)
    {
        var response = await _updatePlayerUseCase.UpdateAsync(id, request, ct);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeletePlayerAsync(Guid id, CancellationToken ct)
    {
        await _deletePlayerUseCase.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetPlayersAsync([FromQuery] GetPlayersRequest request, CancellationToken ct)
    {
        var response = await _getPlayersUseCase.GetAsync(request, ct);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPlayerByIdAsync(Guid id, CancellationToken ct)
    {
        var response = await _getPlayerByIdUseCase.GetPlayerByIdAsync(id, ct);
        return Ok(response);
    }
}
