using System.ComponentModel.DataAnnotations;

namespace AssiT.Core.Entities
{
    public class Category: BaseEntity
    {
        public Category(string name):base(DateTime.Now)
        {
            name = name;
        }

        [MaxLength(15)]
        public string Name { get; set; }
        public ICollection<Asset> Assets { get; set; }
        public void Update(Category  categoryUpdated)
        {
            Name = string.IsNullOrEmpty(categoryUpdated.Name) ? Name : categoryUpdated.Name;
        }
    }
}