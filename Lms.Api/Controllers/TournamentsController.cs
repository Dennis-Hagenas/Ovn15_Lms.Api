using Microsoft.AspNetCore.Mvc;
using Lms.Core.Entities;
using Lms.Data.Repositories;
using AutoMapper;
using Lms.Core.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace Lms.Api.Controllers
{
    [Route("api/tournament")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private IUnitOfWork uow;
        private readonly IMapper mapper;

        public TournamentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournament(bool includeGames)
        {
            var tournament = await uow.TournamentRepository.GetAllAsync(includeGames);
            var dto = mapper.Map<IEnumerable<TournamentDto>>(tournament);

            return Ok(dto);
        }

        // GET: api/Tournaments
        [HttpGet]
        [Route("{title}")]
        public async Task<ActionResult<TournamentDto>> GetTournament(string title, bool includeGames)
        {
            if (string.IsNullOrWhiteSpace(title)) return BadRequest();

            var tournament = await uow.TournamentRepository.GetAsync(title, includeGames);

            if(tournament == null) return NotFound();

            var dto = mapper.Map<TournamentDto>(tournament);

            return Ok(dto);
        }



        [HttpPost]
       public async Task<ActionResult<TournamentDto>> PostTournament(TournamentDto dto)  
        {
            if (await uow.TournamentRepository.GetAsync(dto.Title) != null)
            {
                ModelState.AddModelError("Name", "Name exists");
                return BadRequest();
            }

            var tournament = mapper.Map<Tournament>(dto);
            await uow.TournamentRepository.AddAsync(tournament);
            await uow.CompleteAsync();
            return CreatedAtAction(nameof(GetTournament), new {name = tournament.Title},mapper.Map<TournamentDto>(dto));
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<TournamentDto>> PutTournament(string name, TournamentDto dto)
        {
            var tournament = await uow.TournamentRepository.GetAsync(name);
            if (tournament == null) return NotFound();

            mapper.Map(dto, tournament);

            await uow.CompleteAsync();

            return Ok(mapper.Map<TournamentDto>(tournament));
        }


        [HttpPatch("{tournamentName}")]
        public async Task<ActionResult<TournamentDto>> PatchTournament(string tournamentName,
            JsonPatchDocument<TournamentDto> patchDocument)
        {
            var tournament = await uow.TournamentRepository.GetAsync(tournamentName);
            if (tournament == null) return NotFound();

            var dto = mapper.Map<TournamentDto>(tournament);

            patchDocument.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);
  
            mapper.Map(dto,tournament);
            await uow.CompleteAsync();
 
            return Ok(mapper.Map<TournamentDto>(tournament));
        }

    }
}
