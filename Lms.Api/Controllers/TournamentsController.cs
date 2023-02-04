using Microsoft.AspNetCore.Mvc;
using Lms.Core.Entities;
using Lms.Data.Repositories;
using AutoMapper;

namespace Lms.Api.Controllers
{
    [Route("api/tournament")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private IUnitOfWork uow;
        private readonly Mapper mapper;

        public TournamentsController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            uow = unitOfWork;
            this.mapper = mapper;
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
