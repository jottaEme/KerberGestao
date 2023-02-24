using AutoMapper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Models.Profiles
{
    public class OrdemServicoProfile : Profile
    {
        public OrdemServicoProfile()
        {
            CreateMap<OrdemServicoOpcoesDto, Ordemservico>()
                .ReverseMap();

            CreateMap<OrdemServicoDto, Ordemservico>()
               .ReverseMap();

            CreateMap<OrdemServicoComNomesDto, Ordemservico>()
               .ReverseMap();
        }
    }
}
