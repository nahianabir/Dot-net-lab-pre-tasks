using AutoMapper;
using FinalApi.Data.Entities;

namespace FinalApi.DTOS

{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<Product, ProductDTO>().ForMember(d => d.Qty, s => s.MapFrom(e => e.Quantity));
        }
    }
}
