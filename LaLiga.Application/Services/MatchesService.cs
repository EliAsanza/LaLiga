using AutoMapper;
using LaLiga.Domain.Entities;
using LaLiga.Domain.Interfaces.Repositories;
using LaLiga.Domain.Interfaces.Services;
using LaLiga.Domain.Models.Matches;

namespace LaLiga.Application.Services
{
    public class MatchesService : IMatchesService
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IMapper _mapper;
        private readonly ITeamsRepository _teamsRepository;
        public MatchesService(IMatchesRepository repository, IMapper mapper, ITeamsRepository teamsRepository)
        {
            _matchesRepository = repository;
            _mapper = mapper;
            _teamsRepository = teamsRepository;
        }

        public IEnumerable<MatchesViewModel> GettAllMatches()
        {
            var result = _matchesRepository.GettAllMatches();
            return result;
        }

        public CreatedMatchesViewModel AddMatches(CreatedMatchesViewModel matchViewModel)
        {
            if (matchViewModel.LocalTeamId == matchViewModel.VisitorTeamId)
                throw new Exception("ERROR - El eq  no puede jugar contra si mismo");

            if (matchViewModel.LocalScore < 0 && matchViewModel.VisitorScore < 0)
                throw new Exception("ERROR - Los datos de Score no son correctos");

            if(matchViewModel.LocalScore > 100|| matchViewModel.VisitorScore > 100)
                throw new Exception("ERROR - Los datos de Score no son correctos");

            var teams = _teamsRepository.GettAllTeams();

            //var localTeam = _teamsRepository.GetTeamById(matchViewModel.LocalTeamId)

            var localTeam = teams.FirstOrDefault(x => x.TeamsId == matchViewModel.LocalTeamId);
            if (localTeam == null)
                throw new Exception("ERROR - Introduzca Local team valido");

            //var visitorTeam = _teamsRepository.GetTeamById(matchViewModel.VisitorTeamId)
            var visitorTeam = teams.FirstOrDefault(x => x.TeamsId == matchViewModel.VisitorTeamId);
            if (visitorTeam == null)
                throw new Exception("ERROR - Introduzca Visitor team valido");

            var matche = _mapper.Map<Matches>(matchViewModel);
            _matchesRepository.AddMatches(matche);

            return matchViewModel;
        }

        public bool DeleteMatch(int matchId)
        {
            return _matchesRepository.DeleteMatch(matchId);
        }

        public UpdateMatchViewModel UpdateMatch(UpdateMatchViewModel matchViewModel)
        {
            if (matchViewModel.MatchesId < 0)
                throw new Exception("ERROR - El id no es correcto");

            if (matchViewModel.LocalScore <0)
                throw new Exception("ERROR - El localScore no puede ser < 0");

            if (matchViewModel.VisitorScore < 0)
                throw new Exception("ERROR - El visitorlScore no puede ser < 0");

            if(matchViewModel.MatchDate < DateTime.Today)
                throw new Exception("ERROR - La fecha no puede ser anterior al dia de hoy");

            var match = _mapper.Map<Matches>(matchViewModel);
            var response = _matchesRepository.UpdateMatch(match);
            if (response ==false)
            {
                return new UpdateMatchViewModel();
            }

            return matchViewModel;
        }
    }
}
