using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.MappingProfiles
{
    public class ClubMapping:Profile
    {
        public ClubMapping()
        {
            CreateMap<Club, ClubDto>();
            CreateMap<CreateClubDto, Club>();
        }
    }
}

