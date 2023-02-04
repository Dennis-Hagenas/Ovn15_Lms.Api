using Microsoft.AspNetCore.Mvc;
using Lms.Core.Entities;
using Lms.Data.Repositories;

namespace Lms.Api.Controllers
{
    [Route("api/tournament")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private IUnitOfWork uow;

        public TournamentsController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
            var events = await uow.TournamenRepository.GetAllAsync();

            return Ok(events);    
        }
    }
}
