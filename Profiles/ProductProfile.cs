using AutoMapper;
using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;

namespace ECommAPIAssessment.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ProductwithIdDTO, Product>();
            CreateMap<Product, ProductwithIdDTO>();
        }
    }
}
