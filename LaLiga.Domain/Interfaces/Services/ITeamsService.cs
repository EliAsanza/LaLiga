using LaLiga.Domain.Entities;
using LaLiga.Domain.Models.Teams;

namespace LaLiga.Domain.Interfaces.Services
{
    public interface ITeamsService
    {
        IEnumerable<Teams>GettAllTeams();//obtener lista de eq
        CreatedTeamsViewModel AddTeams(CreatedTeamsViewModel teams);//agregar eq
        bool DeleteTeams(int teamId);//eliminar eq by id
        UpdateTeamViewModel UpdateTeams(UpdateTeamViewModel teams);//editar eq 
        IEnumerable<Teams> GetAllTeamsCreatedSinceYear(DateTime year);//obtener  lista de eq > a x fecha

    }
}
