using LaLiga.Domain.Entities;
using LaLiga.Domain.Models.Matches;

namespace LaLiga.Domain.Interfaces.Repositories
{
    public interface IMatchesRepository
    {
        IEnumerable<MatchesViewModel> GettAllMatches();//obtener listado de partidos
        Matches AddMatches(Matches matches); //agregar partidos
        bool DeleteMatch(int matchId);//eliminar partidos by id
        bool UpdateMatch(Matches match);//editar partidos
    }
}
