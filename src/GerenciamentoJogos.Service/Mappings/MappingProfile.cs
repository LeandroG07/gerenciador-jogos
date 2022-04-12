using AutoMapper;
using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Models;

namespace GerenciamentoJogos.Service.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Amigo, AmigoModel>();
            CreateMap<AmigoModel, Amigo>();

            CreateMap<JogoModel, Jogo>();
            CreateMap<Jogo, JogoModel>();

            CreateMap<LoginModel, Login>();
            CreateMap<Login, LoginModel>();

            CreateMap<EmprestimoModel, Emprestimo>();
            CreateMap<Emprestimo, EmprestimoModel>();
        }

    }
}
