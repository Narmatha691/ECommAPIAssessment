using AutoMapper;
using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;

namespace ECommAPIAssessment.Profiles
{
    public class OrdreProfile:Profile
    {
        public OrdreProfile() 
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderwithIdDTO, Order>();
            CreateMap<Order, OrderwithIdDTO>();
        }
    }
}
