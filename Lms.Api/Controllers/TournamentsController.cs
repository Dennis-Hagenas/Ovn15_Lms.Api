using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Core.Entities;
using Lms.Data.Data;
using Lms.Data.Repositories;

namespace Lms.Api.Controllers
{
    [Route("api/tournament")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private UnitOfWork uow;

        public TournamentsController(LmsApiContext db)
        {
            uow = new UnitOfWork(db);
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
            var events = await uow.TournamenRepository.GetAsync();

            return Ok(events);    
        }

    }
}
