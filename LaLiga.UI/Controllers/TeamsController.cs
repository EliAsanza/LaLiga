using LaLiga.Application.Services;
using LaLiga.Domain.Entities;
using LaLiga.Domain.Interfaces.Services;
using LaLiga.Domain.Models.Teams;
using Microsoft.AspNetCore.Mvc;

namespace LaLiga.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : Controller
    {
        private readonly ITeamsService _teamsServices;

        public TeamsController(ITeamsService teamsService) 
        {
            _teamsServices = teamsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ObtnerListaTeams")]
        public IActionResult GettAllTeams()
        {
            try
            {
                return Ok(_teamsServices.GettAllTeams());
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        [HttpPost]
        public IActionResult AddNewTeams(CreatedTeamsViewModel teamsViewModel)
        {
            return Ok(_teamsServices.AddTeams(teamsViewModel));
        }

        [HttpDelete]
        public IActionResult DeleteTeamById(int teamId)
        {
            try
            {
                return Ok(_teamsServices.DeleteTeams(teamId));
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        [HttpPut]
        public IActionResult UpdateUpdateTeams([FromBody]UpdateTeamViewModel updateTeamViewModel)
        {
            try
            {
                return Ok(_teamsServices.UpdateTeams(updateTeamViewModel));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        
        [HttpGet]
        [Route("ObtenerTeamsByYear")]
        public IActionResult GetAllTeamsCreatedSinceYear(DateTime year)
        {
            try
            {
                var listTeams = _teamsServices.GetAllTeamsCreatedSinceYear(year);
                return Ok(listTeams);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
