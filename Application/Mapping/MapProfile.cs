using Application.Dtos.Products;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            // Product DTO Profiles
            CreateMap<ProductCreateDto, Product>().ReverseMap();

        }
    }
}