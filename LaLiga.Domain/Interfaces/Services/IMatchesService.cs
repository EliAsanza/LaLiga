using LaLiga.Domain.Entities;
using LaLiga.Domain.Models.Matches;
using LaLiga.Domain.Models.Teams;

namespace LaLiga.Domain.Interfaces.Services
{
    public interface IMatchesService
    {
        IEnumerable<MatchesViewModel> GettAllMatches();//obtener listado de partidos
        CreatedMatchesViewModel AddMatches(CreatedMatchesViewModel matches); //agregar partidos
        bool DeleteMatch(int matchId);//eliminar partidos by id
        UpdateMatchViewModel UpdateMatch(UpdateMatchViewModel match);//editar partidos
    }
}