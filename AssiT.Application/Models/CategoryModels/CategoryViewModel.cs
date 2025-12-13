using AssiT.Core.Entities;

namespace AssiT.Application.Models.userModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public static CategoryViewModel FromEntity(Category category) =>
            new CategoryViewModel(
                id:category.Id,
                name: category.Name
             );
    }
}
