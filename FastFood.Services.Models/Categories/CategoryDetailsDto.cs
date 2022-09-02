namespace FastFood.Services.Models.Categories
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<string> Items { get; set; }
    }
}
