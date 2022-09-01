using FastFood.Services.Models.Categories;
using FastFood.Web.ViewModels.Categories;

namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateCategoryDto, Category>();
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, ListCategoryDto>();

            this.CreateMap<ListCategoryDto, CategoryAllViewModel>();

        }
    }
}
