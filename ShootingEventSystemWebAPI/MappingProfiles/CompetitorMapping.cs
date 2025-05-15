using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.MappingProfiles
{
    public class CompetitorMapping:Profile
    {
        public CompetitorMapping()
        {
            CreateMap<Competitor, CompetitorDto>();
            CreateMap<CreateCompetitorDto, Competitor>();

        }
    }
}
