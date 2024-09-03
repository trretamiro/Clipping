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
            CreateMap<CriarNoticiaViewModel, Noticia>();
        }
    }
}
