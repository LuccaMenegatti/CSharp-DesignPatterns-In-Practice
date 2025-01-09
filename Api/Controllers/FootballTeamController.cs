using CSharpDesignPatternsInPractice.Domain.Dtos.Request;
using CSharpDesignPatternsInPractice.Domain.UseCases.FootballTeams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharpDesignPatternsInPractice.Api.Controllers;

[ApiController]
[Route("football_teams")]
public class FootballTeamController(
    ICreateTeamUseCase createTeamUseCase,
    IUpdateTeamUseCase updateTeamUseCase,
    IDeleteTeamUseCase deleteTeamUseCase,
    IGetTeamsUseCase getTeamsUseCase,
    IGetTeamByIdUseCase getTeamByIdUseCase) : ControllerBase
{
    private readonly ICreateTeamUseCase _createTeamUseCase = createTeamUseCase;
    private readonly IUpdateTeamUseCase _updateTeamUseCase = updateTeamUseCase;
    private readonly IDeleteTeamUseCase _deleteTeamUseCase = deleteTeamUseCase;
    private readonly IGetTeamsUseCase _getTeamsUseCase = getTeamsUseCase;
    private readonly IGetTeamByIdUseCase _getTeamByIdUseCase = getTeamByIdUseCase;

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateTeamAsync([FromBody] CreateFootballTeamRequest request, CancellationToken ct)
    {
        var response = await _createTeamUseCase.CreateTeamAsync(request, ct);
        return Created(nameof(CreateTeamAsync), response);
    }

    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateTeamAsync(Guid id, [FromBody] UpdateFootballTeamRequest request, CancellationToken ct)
    {
        var response = await _updateTeamUseCase.UpdateAsync(id, request, ct);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteTeamAsync(Guid id, CancellationToken ct)
    {
        await _deleteTeamUseCase.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetTeamsAsync([FromQuery] GetTeamsRequest request, CancellationToken ct)
    {
        var response = await _getTeamsUseCase.GetAsync(request, ct);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetTeamByIdAsync(Guid id, CancellationToken ct)
    {
        var response = await _getTeamByIdUseCase.GetTeamByIdAsync(id, ct);
        return Ok(response);
    }
}
