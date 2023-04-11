using LaLiga.Domain.Interfaces.Services;
using LaLiga.Domain.Models.Matches;
using Microsoft.AspNetCore.Mvc;

namespace LaLiga.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchesController : Controller
    {
        private readonly IMatchesService _matchesService;
        public MatchesController(IMatchesService service)
        {
            _matchesService = service;
        }

        //get
        public IActionResult Index()
        {
            var result = _matchesService.GettAllMatches();
            return View(result);
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult GettAllMatches()
        {
            var result = _matchesService.GettAllMatches();

            //return result
            //json
            //listado
            //return jso(listado de juegos)
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult AddNewMatch(CreatedMatchesViewModel matchesViewModel) 
        {
            try
            {
                return Ok(_matchesService.AddMatches(matchesViewModel));

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpDelete]
        public IActionResult DeleteMatch(int matchId)
        {
            try
            {
                return new JsonResult(_matchesService.DeleteMatch(matchId));

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        [HttpPut]
        public IActionResult UpdateMatch([FromBody]UpdateMatchViewModel updateMatchViewModel)
        {
            try
            {
                return new JsonResult(_matchesService.UpdateMatch(updateMatchViewModel));
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }




    }
}
