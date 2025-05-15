using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.MappingProfiles
{
    public class ResultMapping: Profile
    {
        public ResultMapping()
        {
            CreateMap<Result, ResultDto>();
            CreateMap<CreateResultDto, Result>();
        }
    }
}
