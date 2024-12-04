using AutoMapper;
using Hamburgueria.Api.Dto_s;
using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;

namespace Hamburgueria.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserPostDto>().ReverseMap();
            CreateMap<Categorie, CategorieDto>().ReverseMap();
            CreateMap<Categorie, CategoriePostDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductPostDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderPostDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Status, StatusPostDto>().ReverseMap();

        }
    }
}
