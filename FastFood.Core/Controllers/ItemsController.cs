using System.Collections;
using System.Collections.Generic;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Items;

namespace FastFood.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using Services.Interfaces;
    using ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;
    public class ItemsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly IItemService itemService;

        public ItemsController(IMapper mapper, ICategoryService categoryService, IItemService itemService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Create()
        { 
            ICollection<ListCategoryDto> categories = await this.categoryService
                .GetAll();

            IList<CreateItemViewModel> itemVmod = new List<CreateItemViewModel>();
            foreach (var category in categories)
            {
                itemVmod.Add(this.mapper.Map<CreateItemViewModel>(category));
            }

            return this.View(itemVmod);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Items");
            }

            bool categoryValid = await this.categoryService.ExistById(model.CategoryId);
            if (!categoryValid)
            {
                return this.RedirectToAction("Create", "Items");

            }

            CreateItemDto itemDto = this.mapper.Map<CreateItemDto>(model);
            await this.itemService.Add(itemDto);

            return this.RedirectToAction("All", "Items");
        }

        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
