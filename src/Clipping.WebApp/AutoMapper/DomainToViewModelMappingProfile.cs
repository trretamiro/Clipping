using AutoMapper;
using Clipping.Domain.Entities;
using Clipping.WebApp.Models;

namespace Clipping.Business.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() 
        {
            CreateMap<Usuario, UsuarioViewModel>();

            CreateMap<Tag, TagViewModel>();

            CreateMap<Noticia, CriarNoticiaViewModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.NoticiaTags.Select(nt => nt.Tag)))
                .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src.Usuario != null ? new List<Usuario> { src.Usuario } : new List<Usuario>()));

            CreateMap<Noticia, NoticiaViewModel>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.NoticiaTags.Select(nt => nt.Tag)))
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));
        }
    }
}
