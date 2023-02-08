using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Core.Entities;
using Lms.Data.Data;
using Lms.Data.Repositories;
using AutoMapper;
using Lms.Core.DTOs;

namespace Lms.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GamesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGame()
        {
            List<Game> games = await uow.GameRepository.GetAllAsync();
            var dto = mapper.Map<IEnumerable<GameDto>>(games);

            return Ok(dto);
        }






        //// GET: api/Games/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Game>> GetGame(int id)
        //{
        //  if (_context.Game == null)
        //  {
        //      return NotFound();
        //  }
        //    var game = await _context.Game.FindAsync(id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return game;
        //}

        //// PUT: api/Games/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGame(int id, Game game)
        //{
        //    if (id != game.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(game).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GameExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Games
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Game>> PostGame(Game game)
        //{
        //  if (_context.Game == null)
        //  {
        //      return Problem("Entity set 'LmsApiContext.Game'  is null.");
        //  }
        //    _context.Game.Add(game);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGame", new { id = game.Id }, game);
        //}

        //// DELETE: api/Games/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGame(int id)
        //{
        //    if (_context.Game == null)
        //    {
        //        return NotFound();
        //    }
        //    var game = await _context.Game.FindAsync(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Game.Remove(game);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool GameExists(int id)
        //{
        //    return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
