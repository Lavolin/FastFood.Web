using FastFood.Services.Models.Categories;

namespace FastFood.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Add(CreateCategoryDto categoryDto);

        Task<ICollection<ListCategoryDto>> GetAll();

        Task<bool> ExistById(int id);
        Task<CategoryDetailsDto> GetDetailById(int id);
    }
}
