using AutoMapper;
using FluentValidation.Results;
using LaLiga.Domain.Entities;
using LaLiga.Domain.Interfaces.Repositories;
using LaLiga.Domain.Interfaces.Services;
using LaLiga.Domain.Models.Teams;
using System.Drawing;
using System.Text.RegularExpressions;

namespace LaLiga.Application.Services
{
    public class TeamsService : ITeamsService 
    {
        private readonly ITeamsRepository _teamsRepository;
        public readonly IMapper _mapper;

        public TeamsService(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _teamsRepository = teamsRepository;
            _mapper = mapper;
        }
       
        public CreatedTeamsViewModel AddTeams(CreatedTeamsViewModel teamsViewModel)
        {
            var teamsViewModel2 = new Validator();//creo una instancia para llamar a la clase validator
            var validacionViewModel2 = teamsViewModel2.Validation(teamsViewModel);//llamo al metodo q esta en validator
            Regex regex = new Regex(@"^-?\d+(?:\.\d+)?$");

            if (teamsViewModel.CreatedDate <= DateTime.Parse("1950/01/01"))
            {
                throw new Exception("ERROR - La fecha de creación no es valida.");
            }
            
            if (regex.IsMatch(teamsViewModel.Color))
            {
                throw new Exception("ERROR - El color no puede ser númerico");
            }

            var listTeams = GettAllTeams();//obtener la lista

            var encontrado= listTeams.FirstOrDefault(x=> x.Name == teamsViewModel.Name);//busco que coincida el nombre introdudicido coincida con lo q est en la BD
            if (encontrado==null)//si no existe el nombre significa que se puede agregar el equipo
            {
                var teams = _mapper.Map<Teams>(teamsViewModel);
                _teamsRepository.AddTeams(teams);
                return teamsViewModel;
            }
            else
            {
                throw new Exception("ERROR - El equipo ya existe.");// caso contrario se muestra el siguiente mensaje
            };
        }
        public IEnumerable<Teams> GettAllTeams()
        {
            var teams = _teamsRepository.GettAllTeams();
            return teams;
        }
        public bool  DeleteTeams(int teamId)
        {
            return _teamsRepository.DeleteTeams(teamId);
        }
        public UpdateTeamViewModel UpdateTeams(UpdateTeamViewModel teamViewModel)
        {
            if (teamViewModel.TeamsId < 0)
                throw new Exception("ERROR - El teamId no es correcto");

            if (string.IsNullOrEmpty(teamViewModel.Name) || string.IsNullOrWhiteSpace(teamViewModel.Name))
                throw new Exception("ERROR - El nombre no puede estar vacío");

            if (string.IsNullOrEmpty(teamViewModel.Color) || string.IsNullOrWhiteSpace(teamViewModel.Color))
                throw new Exception("ERROR - El color no puede estar vacío");

            var teams = _mapper.Map<Teams>(teamViewModel);
            var response = _teamsRepository.UpdateTeams(teams);
            if (response==true)
            {
                 return teamViewModel;
            }
            else
            {
                return new UpdateTeamViewModel();
            }
        }
        public IEnumerable<Teams> GetAllTeamsCreatedSinceYear(DateTime year)//piden los utlimos equipos q fueron creados desde el año x
        {
            if (year == null)
               throw new Exception("Debe introducir una fecha");
            
            var teamsSinceYear = _teamsRepository.GetAllTeamsCreatedSinceYear(year);
            return teamsSinceYear;
        }
    }
}
