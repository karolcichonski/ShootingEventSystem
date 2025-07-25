﻿using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/tournament")]
    public class TournamentController:ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetAllTournamentsAsync()
        {
            var tournaments = await _tournamentService.GetAllTournamentsAsync();
            return Ok(tournaments);
        }

        [HttpPost]
        public ActionResult<int> CreateTournament([FromBody] CreateTournamentDto tournamentDto)
        {
            if (tournamentDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var tournamentId = _tournamentService.CreateTournament(tournamentDto);
            return CreatedAtAction(nameof(GetById), new { id = tournamentId }, tournamentId);
        }

        [HttpGet("ById")]
        public ActionResult<TournamentDto> GetById([FromQuery] int id)
        {
            var tournament = _tournamentService.GetById(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament);
        }
    }
}
