using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.MappingProfiles
{
    public class ArbiterMapping : Profile
    {
        public ArbiterMapping()
        {
            CreateMap<Arbiter, ArbiterDto>();
            CreateMap<CreateArbiterDto, Arbiter>();
        }
    }
}
