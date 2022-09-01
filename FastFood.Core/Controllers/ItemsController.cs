using System.Collections;
using System.Collections.Generic;
using FastFood.Services.Models.Categories;

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
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public ItemsController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
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
        public IActionResult Create(CreateItemInputModel model)
        {
            throw new NotImplementedException();
        }

        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
