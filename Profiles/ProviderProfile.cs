using AutoMapper;
using RiskTrack.DTOs;
using RiskTrack.Models;

namespace RiskTrack.Profiles{
    public class ProviderProfile : Profile {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderReadDTO>();
            CreateMap<ProviderCreateDTO, Provider>();
        }
    }
}