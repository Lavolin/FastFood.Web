using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Items;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Items;

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

            //Categories
            this.CreateMap<CreateCategoryDto, Category>();
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, ListCategoryDto>();

            this.CreateMap<ListCategoryDto, CategoryAllViewModel>();

            //Item
            this.CreateMap<ListCategoryDto, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, mo => mo.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryName, mo => mo.MapFrom(s => s.Name));
            this.CreateMap<CreateItemInputModel, CreateItemDto>();
            this.CreateMap<CreateItemDto, Item>();
        }
    }
}
