using AutoMapper;
using PIA_BackEnd.DTOs;
using PIA_BackEnd.Entities;

namespace PIA_BackEnd.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RaffleDTO, Raffle>();
        }
    }
}
