using AutoMapper;
using Clipping.Domain.Entities;
using Clipping.WebApp.Models;

namespace Clipping.Business.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<TagViewModel, Tag>();
            CreateMap<NoticiaViewModel, Noticia>();
            CreateMap<CriarNoticiaViewModel, Noticia>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuarios.FirstOrDefault()));

        }
    }
}
