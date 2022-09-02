namespace FastFood.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<string> Items { get; set; }
    }
}
