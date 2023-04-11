using AutoMapper;
using LaLiga.Domain.Entities;
using LaLiga.Domain.Models.Matches;
using LaLiga.Domain.Models.Teams;

namespace LaLiga.Application.Mapping
{
    public class LaLigaProfile: Profile
    {

        public LaLigaProfile() 
        {
            CreateMap<CreatedTeamsViewModel, Teams>();
            CreateMap<Teams, CreatedTeamsViewModel>();
            CreateMap<UpdateTeamViewModel, Teams>();
            CreateMap<Teams, UpdateTeamViewModel>();
            CreateMap<CreatedMatchesViewModel, Matches>();
            CreateMap<Matches, CreatedMatchesViewModel>();
            CreateMap<UpdateMatchViewModel, Matches>();
            CreateMap<Matches, UpdateMatchViewModel>();
        }
    }
}
