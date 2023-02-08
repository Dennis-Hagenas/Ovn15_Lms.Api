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
       public async Task<ActionResult<TournamentDto>> CreateTournament(CreateTournamentDto dto)
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

        [HttpPatch("{tournamentId}")]
        public async Task<ActionResult<TournamentDto>> PatchTournament(int tournmentId,
            JsonPatchDocument<TournamentDto> patchDocument)
        {
            var tourrnament = await uow.TournamentRepository.GetAsync(tournmentId);
            if (tourrnament == null) return NotFound();

            var dto = mapper.Map<TournamentDto>(tourrnament);

            patchDocument.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);



            mapper.Map(dto,tourrnament);
            await uow.CompleteAsync();



            return Ok(mapper.Map<TournamentDto>(tourrnament));
        }

    }
}
