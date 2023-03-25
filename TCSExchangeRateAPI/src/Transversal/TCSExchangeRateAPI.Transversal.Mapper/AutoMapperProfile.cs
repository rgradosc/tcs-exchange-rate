using AutoMapper;
using TCSExchangeRateAPI.Application.DTO;
using TCSExchangeRateAPI.Domain.Entity;

namespace TCSExchangeRateAPI.Transversal.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Symbol, SymbolDTO>()
                .ForMember(x => x.Code, opt => opt.MapFrom(s => s.SymbolCode))
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.SymbolName))
                .ReverseMap();
        }
    }
}
