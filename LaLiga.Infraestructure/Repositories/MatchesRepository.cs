using LaLiga.Domain.Entities;
using LaLiga.Domain.Interfaces.Repositories;
using LaLiga.Domain.Models.Matches;
using LaLiga.Infraestructure.Persistence;

namespace LaLiga.Infraestructure.Repositories
{
    public class MatchesRepository : IMatchesRepository
    {
        private readonly LaLigaContext _context;
        public MatchesRepository(LaLigaContext context)
        {
            _context = context;
        }

        public IEnumerable<MatchesViewModel> GettAllMatches()
        {
            var matches = (from m in _context.Matchess
                           join tl in _context.Teams on m.LocalTeamId equals tl.TeamsId
                           join tv in _context.Teams on m.VisitorTeamId equals tv.TeamsId
                           select new MatchesViewModel
                           {
                               Id = m.MatchesId,
                               MatchDate = m.MatchDate,
                               LocalTeam = tl.Name,
                               VisitorTeam = tv.Name,
                               LocalScore = m.LocalScore,
                               VisitorScore = m.VisitorScore,
                               Winner = (m.LocalScore == m.VisitorScore) ? "" : (m.LocalScore > m.VisitorScore) ? tl.Name : tv.Name
                           }).ToList();
            return matches;
        }
        public Matches AddMatches(Matches matches)
        {
            _context.Matchess.Add(matches);
            _context.SaveChanges();
            return matches;
        }

        public bool DeleteMatch(int matchId)
        {
            if (matchId < 0)// valido q el id no sea < a 0
            {
                return false;
            }

            var match = _context.Matchess.FirstOrDefault(x=> x.MatchesId == matchId); // busca q el id introducido corresponda con a algun id en la bd
            if (match == null)// valido que no sea null, en caso de q no lo encuentre en l bd
            {
                return false;
            }
            _context.Matchess.Remove(match);//encontrado, lo elimima
            _context.SaveChanges();//lo guarda
            return true;//lo devuelve
        }

        public bool UpdateMatch(Matches match)
        {
            var matchDb = _context.Matchess.FirstOrDefault(x=> x.MatchesId == match.MatchesId);
            if (matchDb == null)
            {
                return false;
            }
            matchDb.MatchDate = match.MatchDate;
            matchDb.LocalScore = match.LocalScore;
            matchDb.VisitorScore = match.VisitorScore;
            _context.SaveChanges();

            return true;
        }


    }
}
