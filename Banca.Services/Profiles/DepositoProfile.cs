using AutoMapper;
using Banca.Domain.Models.Dto;
using Banca.Infrastructure.Modelos;

namespace Banca.Services.Profiles
{
    public class DepositoProfile : Profile
    {
        public DepositoProfile() =>
        CreateMap<Deposito, DepositoDto>()
        .ForMember(dest => dest.CtaAhorro, opt => opt.MapFrom(src => src.CuentaAhorro)) //Para hacer el matching en caso de que los campos no se llamen igual
        .ReverseMap(); //Para indicar que el mapeo ha de ser de Deposito <-> DepositoDto o DepositoDto <-> Deposito
    }
}
