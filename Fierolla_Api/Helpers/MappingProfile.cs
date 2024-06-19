using AutoMapper;
using Fierolla_Api.DTOs.Blogs;
using Fierolla_Api.DTOs.Ctegories;
using Fierolla_Api.DTOs.Products;
using Fierolla_Api.DTOs.Sliders;
using Fierolla_Api.Models;
using System.Diagnostics.Metrics;

namespace Fierolla_Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        //    CreateMap<Slider, SliderDTo>()
        //          .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedDate)).ReverseMap();

            CreateMap<SliderCreateDTo, Slider>();
            CreateMap<SliderEditDTo, Slider>();
            CreateMap<Slider, SliderDTo>();

            CreateMap<CategoryDTo, Category>();
            CreateMap<CategoryCreateDTo, Category>();
            CreateMap<CategoryEditDto, Category>();

            CreateMap<BlogDTo, Blog>();
            CreateMap<BlogCreateDTo, Blog>();
            CreateMap<BlogEditDTo, Blog>();

            CreateMap<ProductDTo, Product>();
            CreateMap<ProductEditDTo, Product>();
            CreateMap <ProductCreateDTo, Product>();
        }

    }
}
