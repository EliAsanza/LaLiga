using LaLiga.Domain.Entities;
using LaLiga.Domain.Models;
using LaLiga.Domain.Models.Teams;

namespace LaLiga.Domain.Interfaces.Repositories
{
    public interface ITeamsRepository
    {
        IEnumerable<Teams> GettAllTeams();//obtener listado de equipos
        Teams AddTeams(Teams teams); //agregar equipos
        bool DeleteTeams(int teamId);//eliminar eq by id
        bool UpdateTeams(Teams teams);//editar eq 
        IEnumerable<Teams> GetAllTeamsCreatedSinceYear(DateTime year); //obtener  lista de eq > a x fecha
    }
}
