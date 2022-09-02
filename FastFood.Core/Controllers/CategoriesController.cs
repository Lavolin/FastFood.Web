using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FastFood.Data;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using FastFood.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Categories");

            }

            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);

            await this.categoryService.Add(categoryDto);

            return this.RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> Details(int id)
        {
            bool validCategory = await this.categoryService.ExistById(id);

            if(!validCategory)
            {
                return this.RedirectToAction("All", "Categories");
            }

            var categoryDto = await this.categoryService.GetDetailById(id);
            var categoryVm = mapper.Map<CategoryDetailsViewModel>(categoryDto);

            return this.View(categoryVm);
        }

        public async Task<IActionResult> All()
        {
            //read all data categories from db and pass it to the View
            ICollection<ListCategoryDto> categoryDtos = await this.categoryService.GetAll();

            IList<CategoryAllViewModel> categoryAll = new List<CategoryAllViewModel>();
            foreach (ListCategoryDto cDto in categoryDtos)
            {
                categoryAll.Add(this.mapper.Map<CategoryAllViewModel>(cDto));
            }
            return this.View(categoryAll);
        }
    }
}
