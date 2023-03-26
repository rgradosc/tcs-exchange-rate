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

            CreateMap<ListExchangeRateDTO, ExchangeRate>()
                .ForMember(x => x.TargetCurrency, opt => opt.MapFrom(s => s.Target))
                .ForMember(x => x.BaseCurrency, opt => opt.MapFrom(s => s.Base))
                .ForMember(x => x.BaseRate, opt => opt.MapFrom(s => s.Rate))
                .ReverseMap();

            CreateMap<UpdateExchangeRateDTO, ExchangeRate>()
                .ForMember(x => x.BaseRate, opt => opt.MapFrom(s => s.Rate))
                .ForMember(x => x.BaseCurrency, opt => opt.MapFrom(s => s.Base))
                .ForMember(x => x.TargetCurrency, opt => opt.MapFrom(s => s.Target))
                .ReverseMap();

            CreateMap<User, UserDTO>();
        }
    }
}
