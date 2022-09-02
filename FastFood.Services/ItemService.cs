using AutoMapper;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Items;

namespace FastFood.Services
{
    public class ItemService : IItemService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        
        public async Task Add(CreateItemDto dto)
        {
            Item item = this.mapper.Map<Item>(dto);

           await this.dbContext.Items.AddAsync(item);
           await this.dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListItemDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
