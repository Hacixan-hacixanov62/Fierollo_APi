using AutoMapper;
using Fierolla_Api.DTOs.Sliders;
using Fierolla_Api.Models;
using System.Diagnostics.Metrics;

namespace Fierolla_Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Slider, SliderDTo>()
                  .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedDate)).ReverseMap();

            CreateMap<SliderCreateDTo, Slider>();

        }

    }
}
