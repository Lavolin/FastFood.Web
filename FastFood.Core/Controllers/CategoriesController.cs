using System;
using AutoMapper;
using FastFood.Data;
using FastFood.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            throw new NotImplementedException();
        }

        public IActionResult All()
        {
            //TODO read all data categories from db and pass it to the View
            throw new NotImplementedException();
        }
    }
}
