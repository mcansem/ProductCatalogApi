using AutoMapper;
using ProductCatalogManagerAPI.Domain.Entity;
using ProductCatalogManagerAPI.Application.Dtos;

namespace ProductCatalogManagerAPI.Application.Mappers
{
    /// <summary>
    /// Mapping profile class.
    /// Operates mapping operations
    /// </summary>
    public class MapProfile : Profile
    {
        /// <summary>
        /// MapProfile class constructor
        /// </summary>
        public MapProfile()
        {
            //Mappings from DTO to Entities and vice-versa
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<IQueryable<Product>, IQueryable<ProductDto>>().ReverseMap();
        }
    }
}