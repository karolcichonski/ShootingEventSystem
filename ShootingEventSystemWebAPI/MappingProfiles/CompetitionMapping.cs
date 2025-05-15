using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.MappingProfiles
{
    public class CompetitionMapping: Profile
    {
        public CompetitionMapping()
        {
            CreateMap<Competition, CompetitionDto>();
            CreateMap<CreateCompetitionDto, Competition>();

        }
    }
}
