using AutoMapper;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.MappingProfiles
{
    public class TournamentMapping:Profile
    {
        public TournamentMapping()
        {
            CreateMap<Entities.Tournament, Models.TournamentDto>()
                .ForMember(m => m.CompetitionName, c => c.MapFrom(t => t.Competition.Name));
            CreateMap<Models.CreateTournamentDto, Entities.Tournament>();
        }
    }
}
