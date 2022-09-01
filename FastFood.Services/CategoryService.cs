using AutoMapper.QueryableExtensions;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    using AutoMapper;

    using Data;
    using Interfaces;
    using Models.Categories;
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext dbContext, IMapper mapper) 
        {
            //dependency injection from StartUp!!!
                this.dbContext = dbContext;
                this.mapper = mapper;
        }
        public async Task Add(CreateCategoryDto categoryDto)
        {
            Category category = this.mapper.Map<Category>(categoryDto);

            dbContext.Categories.Add(category);

            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListCategoryDto>> GetAll()
        {
            ICollection<ListCategoryDto> result = await this.dbContext
                .Categories
                .ProjectTo<ListCategoryDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return result;
        }
    }
}