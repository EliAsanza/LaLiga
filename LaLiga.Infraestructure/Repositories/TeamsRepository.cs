using LaLiga.Domain.Entities;
using LaLiga.Domain.Interfaces.Repositories;
using LaLiga.Domain.Models.Teams;
using LaLiga.Infraestructure.Persistence;

namespace LaLiga.Infraestructure.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly LaLigaContext _context;
        public TeamsRepository(LaLigaContext context) 
        {
            _context = context;
        }
       
        public IEnumerable<Teams> GettAllTeams()
        {
            var teams = _context.Teams.ToList();
            return teams;
        }

        public Teams AddTeams(Teams teams)
        {
            _context.Teams.Add(teams);
            _context.SaveChanges();
            return teams;
        }
        public bool DeleteTeams(int teamId)
        {
            if (teamId <0)
            {
                return false;
            }

            var team = _context.Teams.FirstOrDefault(x=> x.TeamsId == teamId);
            if (team == null)
                return false;

            _context.Teams.Remove(team);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateTeams(Teams teams)
        {
            var teamDb = _context.Teams.FirstOrDefault(x => x.TeamsId == teams.TeamsId);
            if(teamDb == null)
                return false;

            teamDb.Name = teams.Name;
            teamDb.Color = teams.Color;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Teams> GetAllTeamsCreatedSinceYear(DateTime year) //piden los utlimos equipos q fueron creados desde el año x
        {
            var teamsSinceYear = _context.Teams.Where(x=> x.CreatedDate <= year);
            if (teamsSinceYear == null || teamsSinceYear.Any()==false)
                throw new Exception("No existen equipos creados en esta fecha");
            return teamsSinceYear;
        }
        
    }
}
